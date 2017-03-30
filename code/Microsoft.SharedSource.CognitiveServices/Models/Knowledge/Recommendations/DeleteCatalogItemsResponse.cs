using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class DeleteCatalogItemsResponse
    {
        public int ProcessedLineCount { get; set; }
        public int ErrorLineCount { get; set; }
        public int DeletedItemCount { get; set; }
        public List<ErrorSummary> ErrorSummary { get; set; }
        public List<ErrorDetails> SampleErrorDetails { get; set; }
    }
}