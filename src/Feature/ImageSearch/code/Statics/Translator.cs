using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Statics
{
    public static class Translator
    {
        public static string Text(string key)
        {
            return Sitecore.Globalization.Translate.TextByDomain(new ImageSearchSettings().DictionaryDomain, key) ?? string.Empty;
        }
    }
}