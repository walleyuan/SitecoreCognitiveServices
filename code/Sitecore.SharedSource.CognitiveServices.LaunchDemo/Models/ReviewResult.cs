using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class ReviewResult
    {
        public GetReviewResponse Review { get; set; }
        public List<string> CreateReviews { get; set; }
    }
}