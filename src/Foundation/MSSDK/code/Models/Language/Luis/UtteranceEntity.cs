using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class UtteranceEntity {
        public string Entity { get; set; }
        public int StartPos { get; set; }
        public int EndPos { get; set; }
    }
}