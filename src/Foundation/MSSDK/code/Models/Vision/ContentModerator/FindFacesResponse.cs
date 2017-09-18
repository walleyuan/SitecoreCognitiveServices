using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class FindFacesResponse
    {
        public List<FindFaceRectangle> Faces { get; set; }
        public int Count { get; set; }
        //public List<object> AdvancedInfo { get; set; }
        public bool Result { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}