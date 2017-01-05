extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Models;
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

            var ciaFactory = DependencyResolver.Current.GetService<ICognitiveImageAnalysisFactory>();
            if (ciaFactory == null)
                return false;

            try {
                ICognitiveImageAnalysis cia = ciaFactory.Create();
                cia.VisionAnalysis = Task.Run(async() => await crContext.VisionRepository.GetFullAnalysis(m)).Result;
                cia.TextAnalysis = Task.Run(async () => await crContext.VisionRepository.RecognizeTextAsync(m, "en")).Result;
                cia.EmotionAnalysis = Task.Run(async () => await crContext.EmotionRepository.RecognizeAsync(m)).Result;
                cia.FacialAnalysis = Task.Run(async () => await crContext.FaceRepository.DetectAsync(m)).Result;
                
                var json = new JavaScriptSerializer().Serialize(cia);
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