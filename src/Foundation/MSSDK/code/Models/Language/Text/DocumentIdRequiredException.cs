using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class DocumentIdRequiredException : Exception {
        public override string Message
        {
            get
            {
                return "A document's Id property is required.";
            }
        }
    }
}
