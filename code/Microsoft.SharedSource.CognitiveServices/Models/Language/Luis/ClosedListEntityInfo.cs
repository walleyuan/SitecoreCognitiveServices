using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ClosedListEntityInfo {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string ReadableType { get; set; }
        public List<ClosedListEntity> Sublists { get; set; }
    }
}