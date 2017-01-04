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

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class ImageItemAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsMediaItem)
                return false;

            MediaItem m = indexItem;

            var csContext = DependencyResolver.Current.GetService<ICognitiveServiceContext>();
            if(csContext == null)
                return false;

            var r = csContext.VisionService.GetFullAnalysis(m);
            var json = new JavaScriptSerializer().Serialize(r);

            return json;
        }
    }
}