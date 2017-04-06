using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.Speech {
    public class ResultProperties {
        /// <summary>
        /// set when the header result is determined to be of high-confidence. 
        /// </summary>
        public string HighConf { get; set; }
        /// <summary>
        /// set when the header result is determined to be of medium-confidence.
        /// </summary>
        public string MidConf { get; set; }
        /// <summary>
        /// set when the header result is determined to be of low-confidence. 
        /// </summary>
        public string LowConf { get; set; }
    }
}
