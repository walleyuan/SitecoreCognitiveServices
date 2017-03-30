using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class UpdateCatalogItemsResponse
    {
        public int ProcessedLineCount { get; set; }
        public int AddedItemCount { get; set; }
        public int UpdatedItemCount { get; set; }
        public int ErrorLineCount { get; set; }
        public List<ErrorSummary> ErrorSummary { get; set; }
        public List<ErrorDetails> SampleErrorDetails { get; set; }
    }
}