using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
{
    public class Condition : IExpression
    {
        public string ConnectorName => "imagemoderator";
        /// <summary>
        /// Values like (adultscore, racyscore, isadult, isracy)
        /// </summary>
        public string OutputName { get; set; }
        /// <summary>
        /// Values like (ge, eq)
        /// </summary>
        public string Operator { get; set; }
        public string Value { get; set; }
        public string Type => "Condition";
    }
}