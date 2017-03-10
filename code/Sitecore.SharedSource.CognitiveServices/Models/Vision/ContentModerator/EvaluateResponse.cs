
namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class EvaluateResponse
    {
        public double AdultClassificationScore { get; set; }
        public bool IsImageAdultClassified { get; set; }
        public double RacyClassificationScore { get; set; }
        public bool IsImageRacyClassified { get; set; }
        //public List<object> AdvancedInfo { get; set; }
        public bool Result { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}