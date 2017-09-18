using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class DocumentCollectionMaxSizeException : Exception {
        public int CollectionSize { get; set; }

        public int MaximumCollectionSize { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document collection is {0} bytes. Document collections have a maximum size of {1} bytes.", (object)this.CollectionSize, (object)this.MaximumCollectionSize);
            }
        }

        public DocumentCollectionMaxSizeException(int collectionSize, int maximumCollectionSize) {
            this.CollectionSize = collectionSize;
            this.MaximumCollectionSize = maximumCollectionSize;
        }
    }
}
