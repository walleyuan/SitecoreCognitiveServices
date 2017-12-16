using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class CreateBusinessRuleRequest
    {
        public string Type { get; set; }
        public BusinessRuleSet Parameters { get; set; }
    }
}