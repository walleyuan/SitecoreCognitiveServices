using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common {
    public class VideoOperation {
        public string Url { get; set; }
        public VideoOperation(string url) {
            this.Url = url;
        }
    }
}
