using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class DocumentCollectionDuplicateIdException : Exception {
        public string DocumentId { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Multiple documents with the id {0} were found. Document id's must be unique per document.", (object)this.DocumentId);
            }
        }

        public DocumentCollectionDuplicateIdException(string documentId) {
            this.DocumentId = documentId;
        }
    }
}
