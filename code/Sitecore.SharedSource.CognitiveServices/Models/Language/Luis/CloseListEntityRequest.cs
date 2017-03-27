using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class CloseListEntityRequest {
        public string Name { get; set; }
        public ClosedListEntity[] Sublists { get; set; }
    }
}