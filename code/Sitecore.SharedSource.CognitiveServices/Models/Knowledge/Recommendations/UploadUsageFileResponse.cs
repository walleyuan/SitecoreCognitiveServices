using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class UploadUsageFileResponse
    {
        public string FileId { get; set; }
        public int ProcessedLineCount { get; set; }
        public int ErrorLineCount { get; set; }
        public int ImportedLineCount { get; set; }
        public List<ErrorSummary> ErrorSummary { get; set; }
        public List<ErrorDetails> SampleErrorDetails { get; set; }
    }
}