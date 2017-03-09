using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class ContentModeratorMatchResponse
    {
        public string TrackingId { get; set; }
        public string CacheId { get; set; }
        public bool IsMatch { get; set; }
        public MatchDetails MatchDetails { get; set; }
    }

    public class MatchDetails
    {
        public float Score { get; set; }
        public string MatchId { get; set; }
        public string Source { get; set; }
        public List<ContentModeratorTags> Tags { get; set; }
        public string Label { get; set; }
    }
}