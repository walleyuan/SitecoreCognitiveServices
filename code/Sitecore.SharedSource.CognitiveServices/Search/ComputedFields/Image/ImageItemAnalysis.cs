using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class ImageItemAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            return string.Empty;
        }
    }
}