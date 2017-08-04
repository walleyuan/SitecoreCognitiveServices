using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public interface IDocument {
        string Id { get; set; }

        int Size { get; }

        string Text { get; set; }
    }
}
