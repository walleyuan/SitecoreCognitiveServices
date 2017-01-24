using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public virtual void SetImageAlt(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (new SecurityDisabler())
            {
                using (new EditContext(mediaItem))
                {
                    try
                    {
                        var result = GetDescription(mediaItem);

                        mediaItem.Alt = (result.Captions != null && result.Captions.Any())
                            ? result.Captions.First().Text
                            : string.Empty;
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