using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public interface IBaseIntentFactory<out T> where T : IIntent {
        T Create();
    }
}