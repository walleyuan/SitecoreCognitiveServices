using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class UpdateModelRequest
    {
        public string Description { get; set; }
        public int ActiveBuildId { get; set; }
    }
}