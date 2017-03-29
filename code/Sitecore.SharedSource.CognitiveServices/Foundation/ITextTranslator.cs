using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public interface ITextTranslator {
        string Translate(string key);
    }
}