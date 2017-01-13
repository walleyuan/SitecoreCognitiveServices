using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class SitecoreContextDatabase : ISitecoreContextDatabase
    {
        public Item GetItemById(string itemId)
        {
            ID idObj;
            return (!ID.TryParse(itemId, out idObj))
                ? null
                : Sitecore.Context.Database.GetItem(idObj);
        }

        public Item GetItem(string itemPath)
        {
            return Sitecore.Context.Database.GetItem(itemPath);
        }
        public Item GetItem(ID itemId)
        {
            return Sitecore.Context.Database.GetItem(itemId);
        }
        public string Name()
        {
            return Sitecore.Context.Database.Name;
        }
    }
}