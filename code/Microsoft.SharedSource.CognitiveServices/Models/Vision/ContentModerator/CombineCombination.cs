using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class CombineCombination : IExpression
    {
        public ConditionCombination Left { get; set; }
        public ConditionCombination Right { get; set; }
        /// <summary>
        /// Values (AND or OR)
        /// </summary>
        public string Combine { get; set; }
        public string Type => "Combine";
    }
}