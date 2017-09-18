using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker {
    public class GenerateAnswerRequest {
        /// <summary>
        /// User question to be queried against your knowledge base.
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Number of ranked results you want in the output. Default is 1.
        /// </summary>
        public int Top { get; set; }
    }
}
