using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Enums;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator
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