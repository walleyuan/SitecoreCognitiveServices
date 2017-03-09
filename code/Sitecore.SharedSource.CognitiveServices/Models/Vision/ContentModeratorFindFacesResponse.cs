using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class ContentModeratorFindFacesResponse
    {
        public List<FindFaceRectangle> Faces { get; set; }
        public int Count { get; set; }
        //public List<object> AdvancedInfo { get; set; }
        public bool Result { get; set; }
        public ContentModeratorResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}