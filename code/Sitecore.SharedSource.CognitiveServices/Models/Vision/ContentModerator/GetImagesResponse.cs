using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class GetImagesResponse
    {
        public int ContentSource { get; set; }
        public List<int> ContentIds { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}