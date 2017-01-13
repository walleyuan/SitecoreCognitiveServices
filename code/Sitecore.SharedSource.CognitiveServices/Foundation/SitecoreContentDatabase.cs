using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class SitecoreContentDatabase : ISitecoreContentDatabase
    {
        public Item GetItemById(string itemId)
        {
            ID idObj;
            return (!ID.TryParse(itemId, out idObj))
                ? null
                : Sitecore.Context.ContentDatabase.GetItem(idObj);
        }

        public Item GetItem(string itemPath)
        {
            return Sitecore.Context.ContentDatabase.GetItem(itemPath);
        }
        public Item GetItem(ID itemId)
        {
            return Sitecore.Context.ContentDatabase.GetItem(itemId);
        }

        public string Name()
        {
            return Sitecore.Context.ContentDatabase.Name;
        }
    }
}