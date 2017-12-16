using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public abstract class TextRequest {
        [JsonProperty("documents")]
        public virtual List<IDocument> Documents { get; set; }

        public TextRequest() {
            this.Documents = new List<IDocument>();
        }

        public virtual void Validate() {
            if (this.Documents == null || this.Documents.Count <= 0)
                throw new DocumentCollectionMinDocumentException(0, 1);
            if (this.Documents.Count > 1000)
                throw new DocumentCollectionMaxDocumentException(this.Documents.Count, 1000);
            int collectionSize = 0;
            List<string> list = new List<string>();
            foreach (IDocument document in this.Documents) {
                if (string.IsNullOrWhiteSpace(document.Id))
                    throw new DocumentIdRequiredException();
                if (list.Contains(document.Id))
                    throw new DocumentCollectionDuplicateIdException(document.Id);
                list.Add(document.Id);
                if (document.Size <= 0)
                    throw new DocumentMinSizeException(document.Id, document.Size, 1);
                if (document.Size > 10240)
                    throw new DocumentMaxSizeException(document.Id, document.Size, 10240);
                collectionSize += document.Size;
            }
            if (collectionSize > 1048576)
                throw new DocumentCollectionMaxSizeException(collectionSize, 1048576);
        }
    }
}
