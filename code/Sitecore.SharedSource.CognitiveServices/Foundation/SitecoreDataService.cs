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
    }
}