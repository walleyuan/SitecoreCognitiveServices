using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class GetOperationStatusResponse
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public string CreatedDateTime { get; set; }
        public string LastActionDateTime { get; set; }
        public float PercentComplete { get; set; }
        public string Message { get; set; }
        public string ResourceLocation { get; set; }
        public Build Result { get; set; }
    }
}