using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.AcademicSearch {
    public class InterpretRule
    {
        public string Name { get; set; }
        public InterpretRuleOutput Output { get; set; }
    }
}