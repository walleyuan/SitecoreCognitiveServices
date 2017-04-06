using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.QnAMaker {
    public class KnowledgeBaseExtractionDetails {
        public Guid KbId { get; set; }
        public DataExtractionResult[] DataExtractionResults { get; set; }
    }
}
