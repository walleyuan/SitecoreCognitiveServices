using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class TermListResult
    {
        public bool EventOccurred { get; set; }
        public bool EventSuccess { get; set; }
        public GetTermsResponse Terms { get; set; }
        public ListDetails List { get; set; }
        public List<ListDetails> Lists { get; set; }
    }
}