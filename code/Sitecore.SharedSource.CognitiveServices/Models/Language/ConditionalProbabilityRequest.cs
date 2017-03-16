using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class ConditionalProbabilityRequest
    {
        public List<ConditionalProbabilityQuery> Queries { get; set; }
    }
}