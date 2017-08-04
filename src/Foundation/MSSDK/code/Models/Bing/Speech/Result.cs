using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech {
    public class Result {
        public string Name { get; set; }
        public string Lexical { get; set; }
        public SpeechToTextToken[] Tokens { get; set; }
        public ResultProperties Properties { get; set; }
    }
}
