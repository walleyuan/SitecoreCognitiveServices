using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class Utterance {
        public string Text { get; set; }
        public string Intent { get; set; }
        public UtteranceEntity[] Entities { get; set; }
    }
}