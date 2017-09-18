using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker {
    public class KnowledgeBaseDetails {
        public string Name { get; set; }
        public QnAPair[] QnAPairs { get; set; }
        public string[] Urls { get; set; }
    }
}
