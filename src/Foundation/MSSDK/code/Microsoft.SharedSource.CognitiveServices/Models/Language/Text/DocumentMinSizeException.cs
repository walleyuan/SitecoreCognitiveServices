using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class DocumentMinSizeException : Exception {
        public string DocumentId { get; set; }

        public int DocumentSize { get; set; }

        public int MinimumDocumentSize { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document {0} is {1} bytes. Documents have a minimum size of {2} bytes.", (object)this.DocumentId, (object)this.DocumentSize, (object)this.MinimumDocumentSize);
            }
        }

        public DocumentMinSizeException(string documentId, int documentSize, int minimumDocumentSize) {
            this.DocumentId = documentId;
            this.DocumentSize = documentSize;
            this.MinimumDocumentSize = minimumDocumentSize;
        }
    }
}
