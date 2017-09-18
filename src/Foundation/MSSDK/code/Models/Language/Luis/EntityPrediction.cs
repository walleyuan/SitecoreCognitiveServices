using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class EntityPrediction {
        public string EntityName { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Phrase { get; set; }
    }
}