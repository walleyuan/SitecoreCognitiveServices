using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class DocumentMaxSizeException : Exception {
        public string DocumentId { get; set; }

        public int DocumentSize { get; set; }

        public int MaximumDocumentSize { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document {0} is {1} bytes. Documents have a maximum size of {2} bytes.", (object)this.DocumentId, (object)this.DocumentSize, (object)this.MaximumDocumentSize);
            }
        }

        public DocumentMaxSizeException(string documentId, int documentSize, int maximumDocumentSize) {
            this.DocumentId = documentId;
            this.DocumentSize = documentSize;
            this.MaximumDocumentSize = maximumDocumentSize;
        }
    }
}
