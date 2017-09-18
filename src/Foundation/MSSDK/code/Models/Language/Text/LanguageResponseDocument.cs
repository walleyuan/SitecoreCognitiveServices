using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class LanguageResponseDocument {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("detectedLanguages")]
        public List<DetectedLanguage> DetectedLanguages { get; set; }

        public LanguageResponseDocument() {
            this.DetectedLanguages = new List<DetectedLanguage>();
        }
    }
}
