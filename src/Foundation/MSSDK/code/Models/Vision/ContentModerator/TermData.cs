using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class TermData
    {
        public string Language { get; set; }
        public List<TermEntity> Terms { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}