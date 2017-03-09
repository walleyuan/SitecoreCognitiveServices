using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class ContentModeratorScreenResponse
    {
        public string OriginalText { get; set; }
        public string NormalizedText { get; set; }
        public string AutoCorrectedText { get; set; }
        public List<ScreenUrl> Urls { get; set; }
        //public object Misrepresentation { get; set; }
        public PersonalIdentifiableInformation PersonalIdentifiableInformation { get; set; }
        public string Language { get; set; }
        public List<TermSet> Terms { get; set; }
        public ContentModeratorResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}