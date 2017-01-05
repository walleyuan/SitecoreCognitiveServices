extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class CumulativeTextFieldAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return false;
            
            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return false;

            try
            {
                var r = crContext.VisionRepository.GetFullAnalysis(indexItem);
                var json = new JavaScriptSerializer().Serialize(r);
                return json;
            }
            catch (Exception ex)
            {
                MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.ClientException exception = ex.InnerException as MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.ClientException;

                if (exception != null)
                    Log.Error($"CumulativeTextFieldAnalysis failed to index {indexItem.Paths.Path}: {exception.Error.Message}", exception, GetType());
                else
                    Log.Error(ex.Message, ex, GetType());
            }

            return false;
        }
    }
}