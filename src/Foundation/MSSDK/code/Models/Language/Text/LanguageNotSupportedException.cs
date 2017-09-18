using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class LanguageNotSupportedException : Exception {
        public string InvalidLanguage { get; set; }

        public List<string> ValidLanguages { get; set; }

        public override string Message
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(string.Format("Language {0} is not supported. Supported languages are:"));
                foreach (string str in this.ValidLanguages)
                    stringBuilder.AppendLine(str);
                return stringBuilder.ToString();
            }
        }

        public LanguageNotSupportedException(string invalidLanguage, List<string> validLanguages) {
            if (validLanguages == null || validLanguages.Count == 0)
                throw new ArgumentNullException("A list of valid languages must be supplied.");
            this.InvalidLanguage = invalidLanguage;
            this.ValidLanguages = validLanguages;
        }
    }
}
