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
    public class VisionAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsMediaItem)
                return false;

            MediaItem m = indexItem;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return false;
            
            try {
                var result = Task.Run(async() => await crContext.VisionRepository.GetFullAnalysis(m)).Result;
                return new JavaScriptSerializer().Serialize(result);
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return false;
        }
    }
}