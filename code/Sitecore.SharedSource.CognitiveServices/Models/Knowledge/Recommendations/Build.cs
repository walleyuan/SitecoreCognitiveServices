using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class Build
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ModelName { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string ModifiedDateTime { get; set; }
        public BuildSet BuildParameters { get; set; }
    }
}