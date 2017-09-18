using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class SentimentRequest : TextRequest {
        public List<string> ValidLanguages { get; set; }

        public SentimentRequest() {
            this.Documents = new List<IDocument>();
            this.ValidLanguages = new List<string>()
            {
        "en",
        "es",
        "fr",
        "pt"
      };
        }

        public override void Validate() {
            base.Validate();
            if (this.ValidLanguages == null || this.ValidLanguages.Count <= 0)
                return;
            foreach (IDocument document in this.Documents) {
                SentimentDocument sentimentDocument = document as SentimentDocument;
                if (!string.IsNullOrEmpty(sentimentDocument.Language) && !this.ValidLanguages.Contains(sentimentDocument.Language))
                    throw new LanguageNotSupportedException(sentimentDocument.Language, this.ValidLanguages);
            }
        }
    }
}
