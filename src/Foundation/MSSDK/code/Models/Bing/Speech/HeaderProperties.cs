using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.Speech {
    public class HeaderProperties {
        public string RequestId { get; set; }
        /// <summary>
        /// set when no speech was detected on the sent audio. 
        /// </summary>
        public string NoSpeech { get; set; }
        /// <summary>
        /// set when no matches were found for the sent audio. 
        /// </summary>
        public string FalseReco { get; set; }
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
        /// <summary>
        /// set when there was an error generating a response.  
        /// </summary>
        public string Error { get; set; }
    }
}
