using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech {
    public class SpeechToTextToken {
        public string Token { get; set; }
        public string Lexical { get; set; }
        public string Pronunciation { get; set; }
    }
}
