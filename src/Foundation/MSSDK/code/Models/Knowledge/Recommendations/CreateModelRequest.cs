using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class CreateModelRequest
    {
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}