using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ClosedListEntity {
        public int Id { get; set; }
        public string CanonicalForm { get; set; }
        public string[] List { get; set; }
    }
}