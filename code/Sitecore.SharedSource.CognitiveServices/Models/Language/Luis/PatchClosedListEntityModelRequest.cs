using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class PatchClosedListEntityModelRequest {
        public ClosedListEntity[] Sublists { get; set; }
    }
}