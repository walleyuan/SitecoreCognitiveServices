using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class DocumentCollectionMaxDocumentException : Exception {
        public int DocumentCount { get; set; }

        public int MaximumDocumentCount { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document collection has [0} documents. The maximum number of documents for a collection is {1}.", (object)this.DocumentCount, (object)this.MaximumDocumentCount);
            }
        }

        public DocumentCollectionMaxDocumentException(int documentCount, int maximumDocumentCount) {
            this.DocumentCount = documentCount;
            this.MaximumDocumentCount = maximumDocumentCount;
        }
    }
}
