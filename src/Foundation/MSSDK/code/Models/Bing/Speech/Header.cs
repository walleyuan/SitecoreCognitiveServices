using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.Speech {
    public class Header {
        public string Status { get; set; }
        public string Scenario { get; set; }
        public string Name { get; set; }
        public string Lexical { get; set; }
        public HeaderProperties Properties { get; set; }
        public Result[] Results { get; set; }
    }
}
