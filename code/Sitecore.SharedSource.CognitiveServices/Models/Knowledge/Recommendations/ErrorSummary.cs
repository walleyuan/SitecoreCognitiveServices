using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class ErrorSummary
    {
        public string ErrorCode { get; set; }
        public int ErrorCodeCount { get; set; }
    }
}