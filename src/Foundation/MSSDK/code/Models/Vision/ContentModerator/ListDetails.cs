using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class ListDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public KeyValuePair<string, string> Metadata { get; set; }
    }
}