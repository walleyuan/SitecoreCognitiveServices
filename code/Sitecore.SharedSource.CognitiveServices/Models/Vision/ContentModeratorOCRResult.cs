using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class ContentModeratorOCRResult
    {
        public List<KeyValue> Metadata { get; set; }
        public string CacheId { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
        public List<OCRCandidate> Candidates { get; set; }
        public ContentModeratorResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}