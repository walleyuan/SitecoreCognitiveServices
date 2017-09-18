using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class TermData
    {
        public string Language { get; set; }
        public List<TermEntity> Terms { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}