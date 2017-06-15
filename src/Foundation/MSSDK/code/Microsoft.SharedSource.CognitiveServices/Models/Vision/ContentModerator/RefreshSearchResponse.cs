using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class RefreshSearchResponse
    {
        public int ContentSourceId { get; set; }
        public bool IsUpdateSuccess { get; set; }
        public List<KeyValue> AdvancedInfo { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}