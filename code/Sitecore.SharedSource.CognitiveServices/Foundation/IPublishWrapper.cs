using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public interface IPublishWrapper
    {
        Handle PublishItem(Item item, Database[] targets, Globalization.Language[] languages, bool deep, bool compareRevisions);
    }
}