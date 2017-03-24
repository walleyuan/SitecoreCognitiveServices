using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class EntityExtractorInfo {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string ReadableType { get; set; }
    }
}