
namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class ContentModeratorEvaluateResponse
    {
        public double AdultClassificationScore { get; set; }
        public bool IsImageAdultClassified { get; set; }
        public double RacyClassificationScore { get; set; }
        public bool IsImageRacyClassified { get; set; }
        //public List<object> AdvancedInfo { get; set; }
        public bool Result { get; set; }
        public ContentModeratorResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}