using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class GetImagesResponse
    {
        public int ContentSource { get; set; }
        public List<int> ContentIds { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}