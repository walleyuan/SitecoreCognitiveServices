using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class VisionService : IVisionService
    {
        public IVisionRepository VisionRepository;
        
        public VisionService(IVisionRepository visionRepository)
        {
            VisionRepository = visionRepository;
        }

        public virtual Description GetDescription(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());
            
            return Task.Run(async () => await VisionRepository.DescribeAsync(mediaItem.GetMediaStream())).Result.Description;
        }
        
        public virtual void SetImageDescription(MediaItem mediaItem, string altDescription)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (new SecurityDisabler())
            {
                using (new EditContext(mediaItem))
                {
                    try
                    {
                        mediaItem.Alt = altDescription;
                    }
                    catch (Exception ex)
                    {
                        var exception = ex.InnerException as ClientException;
                        if (exception != null)
                            Log.Error("SetAutoAltTag: " + exception.Error.Message, exception, GetType());
                        else
                            Log.Error("SetAutoAltTag: " + ex.Message, ex, GetType());
                    }
                }
            }
        }
    }
}