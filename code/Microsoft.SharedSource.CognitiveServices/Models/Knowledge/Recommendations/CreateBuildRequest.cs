using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class CreateBuildRequest
    {
        public string Description { get; set; }
        public string BuildType { get; set; }
        public BuildSet Parameters { get; set; }
    }
}