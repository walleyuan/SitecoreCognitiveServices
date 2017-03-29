using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Intents {
    public interface IIntentProvider
    {
        IIntent GetIntent(Guid appId, string intentName);
    }
}