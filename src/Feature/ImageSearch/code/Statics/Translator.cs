using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Globalization;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Statics
{
    public static class Translator
    {
        public static string Text(string key)
        {
            var settings = new ImageSearchSettings();
            var db = Sitecore.Configuration.Factory.GetDatabase(settings.MasterDatabase);

            using (new DatabaseSwitcher(db))
            {
                return Translate.TextByDomain(settings.DictionaryDomain, key) ?? string.Empty;
            }
        }
    }
}