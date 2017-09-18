using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class SentimentDocument : Document, IDocument {
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
