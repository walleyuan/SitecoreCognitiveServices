using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class MatchDetails
    {
        public float Score { get; set; }
        public string MatchId { get; set; }
        public string Source { get; set; }
        public List<ContentModeratorTag> Tags { get; set; }
        public string Label { get; set; }
    }
}