using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class CumulativeTextFieldAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            return string.Empty;
        }
    }
}