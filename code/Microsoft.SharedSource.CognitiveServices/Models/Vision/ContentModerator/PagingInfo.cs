using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class PagingInfo
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Returned { get; set; }
    }
}