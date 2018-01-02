using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Pipelines.RenderField;
using SitecoreCognitiveServices.Foundation.IBMSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Repositories
{
    public class IBMWatsonApiKeys : IIBMWatsonApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IApplicationSettings Settings;

        public IBMWatsonApiKeys(
            ISitecoreDataWrapper dataWrapper,
            IApplicationSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;
        }

        #endregion Constructor 
        
        public virtual string NaturalLanguageClassifier => GetStringValue("Natural Language Classifier");
        public virtual string NaturalLanguageClassifierEndpoint => GetStringValue("Natural Language Classifier Endpoint");
        public virtual string NaturalLanguageClassifierUsername => GetStringValue("Natural Language Classifier Username");
        public virtual string NaturalLanguageClassifierPassword => GetStringValue("Natural Language Classifier Password");
        public virtual int NaturalLanguageClassifierRetryInSeconds => GetIntValue("Natural Language Classifier Retry In Seconds");

        public string GetStringValue(string fieldName)
        {
            return DataWrapper
                .ContentDatabase
                .GetItem(Settings.IBMSDKId)
                [fieldName];
        }
        
        public int GetIntValue(string fieldName)
        {
            return Convert.ToInt32(GetStringValue(fieldName));
        }
    }
}