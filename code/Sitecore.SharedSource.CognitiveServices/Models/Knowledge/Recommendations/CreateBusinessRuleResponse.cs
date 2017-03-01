using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class CreateBusinessRuleResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public BusinessRuleSet Parameters { get; set; }
    }
}