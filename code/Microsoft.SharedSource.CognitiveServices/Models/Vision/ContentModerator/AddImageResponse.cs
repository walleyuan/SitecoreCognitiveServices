using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class AddImageResponse
    {
        public int ContentId { get; set; }
        public List<KeyValue> AdditionalInfo { get; set; }
        public ResponseStatus Status { get; set; }
        public string Trackingid { get; set; }
    }
}