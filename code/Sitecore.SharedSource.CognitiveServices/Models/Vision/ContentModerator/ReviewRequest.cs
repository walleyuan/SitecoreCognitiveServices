using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class ReviewRequest
    {
        public List<KeyValue> MetaData { get; set; }
        public ContentModeratorReviewType Type { get; set; }
        public string Content { get; set; }
        public string ContentId { get; set; }
        public string CallBackEndpoint { get; set; }
    }
}