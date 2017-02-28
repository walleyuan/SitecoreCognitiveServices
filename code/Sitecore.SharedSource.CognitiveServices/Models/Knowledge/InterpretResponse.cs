using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge
{
    public class InterpretResponse
    {
        public string Query { get; set; }
        public List<InterpretResult> Interpretations { get; set; }
    }
}