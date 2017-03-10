using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class OCRResult
    {
        public List<KeyValue> Metadata { get; set; }
        public string CacheId { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
        public List<OCRCandidate> Candidates { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}