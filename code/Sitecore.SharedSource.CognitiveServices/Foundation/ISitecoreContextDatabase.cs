using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public interface ISitecoreContextDatabase
    {
        Item GetItemById(string itemId);
        Item GetItem(string itemPath);
        Item GetItem(ID itemId);
        string Name();
    }
}