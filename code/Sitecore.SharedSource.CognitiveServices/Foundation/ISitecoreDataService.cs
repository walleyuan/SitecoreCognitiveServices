using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public interface ISitecoreDataService
    {
        Database GetDatabase(string dbName);
        ID GetID(string itemId);
    }
}