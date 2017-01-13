using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class SitecoreDataService : ISitecoreDataService
    {
        public Database GetDatabase(string dbName) => Sitecore.Configuration.Factory.GetDatabase(dbName);
        public ID GetID(string itemId)
        {
            ID idObj;
            return (ID.TryParse(itemId, out idObj))
                ? idObj
                : ID.Null;
        }

        public Item GetItemByUri(string itemUri)
        {
            //item uri format: sitecore://master/{04dad0fd-db66-4070-881f-17264ca257e1}?lang=en&ver=1
            string[] parts = itemUri
                .Replace("sitecore://", string.Empty)
                .Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];

            if (parts.Length < 1)
                return null;

            if (parts.Length < 2)
                return null;

            var guidParts = parts[1].Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (guidParts.Length < 1)
                return null;
            
            return GetDatabase(parts[0]).GetItem(GetID(guidParts[0]));
        }
    }
}