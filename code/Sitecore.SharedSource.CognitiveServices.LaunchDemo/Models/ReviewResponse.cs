using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class ReviewResponse
    {
        public GetReviewResponse Review { get; set; }
        public List<string> CreateReviews { get; set; }
    }
}