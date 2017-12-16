using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class AddImageResponse
    {
        public int ContentId { get; set; }
        public List<KeyValue> AdditionalInfo { get; set; }
        public ResponseStatus Status { get; set; }
        public string Trackingid { get; set; }
    }
}