using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.Speech {
    public class Result {
        public string Name { get; set; }
        public string Lexical { get; set; }
        public SpeechToTextToken[] Tokens { get; set; }
        public ResultProperties Properties { get; set; }
    }
}
