using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class ListDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public KeyValuePair<string, string> Metadata { get; set; }
    }
}