using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class LanguageRequest : TextRequest {
        [JsonIgnore]
        public int NumberOfLanguagesToDetect { get; set; }

        public LanguageRequest() {
            this.NumberOfLanguagesToDetect = 1;
        }
    }
}
