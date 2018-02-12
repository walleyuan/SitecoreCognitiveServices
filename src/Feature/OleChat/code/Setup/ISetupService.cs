using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Setup
{
    public interface ISetupService
    {
        void SaveKeys(string luisApi, string luisApiEndpoint, string textAnalyticsApi, string textAnalyticsApiEndpoint);
        bool RestoreOle(bool overwrite);
        bool QueryOle();
        void PublishOleContent();
    }
}