using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public class TextTranslator : ITextTranslator {
        public string Translate(string key) {        
            return Sitecore.Globalization.Translate.Text(key) ?? string.Empty;
        }
    }
}