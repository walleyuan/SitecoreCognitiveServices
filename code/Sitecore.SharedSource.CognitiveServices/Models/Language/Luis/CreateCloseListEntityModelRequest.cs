using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class CreateCloseListEntityModelRequest {
        public string Name { get; set; }
        public EntityExtractorSublist[] Sublists { get; set; }
    }
}