using System.Collections.Generic;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
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