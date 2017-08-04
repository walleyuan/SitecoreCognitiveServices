using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator {
    public class AddImageRequest
    {
        public string DataRepresentation = "URL";
        public string Value { get; set; }
    }
}
