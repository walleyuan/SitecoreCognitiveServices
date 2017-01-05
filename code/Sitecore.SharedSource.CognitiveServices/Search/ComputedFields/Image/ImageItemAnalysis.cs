extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Services;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class ImageItemAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsMediaItem)
                return false;

            MediaItem m = indexItem;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();

            if (crContext == null)
                return false;

            var apiService = DependencyResolver.Current.GetService<IApiService>();
            if (apiService == null)
                return false;
            
            try { 
                var r1 = crContext.VisionRepository.GetFullAnalysis(m);
                var r2 = crContext.VisionRepository.RecognizeTextAsync(m, "en");
                var r3 = crContext.EmotionRepository.RecognizeAsync(m);
                var r4 = crContext.FaceRepository.DetectAsync(m);

                var srlzr = new JavaScriptSerializer();
                var json = srlzr.Serialize(r1);
                return json;
            }
            catch (Exception ex)
            {
                MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.ClientException exception = ex.InnerException as MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.ClientException;

                if (exception != null)
                    Log.Error($"ImageItemAnalysis failed to index {indexItem.Paths.Path}: {exception.Error.Message}", exception, GetType());
                else
                    Log.Error(ex.Message, ex, GetType());
            }

            return false;
        }
    }
}