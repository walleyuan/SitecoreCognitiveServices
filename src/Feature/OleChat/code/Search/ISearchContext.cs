using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Search
{
    public interface ISearchContext
    {
        IEnumerable<ISearchResult> Search(Database db, string scope, TemplateItem template, string fieldName, SearchModifier modifier, string searchValue, string language);
    }
}