using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
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