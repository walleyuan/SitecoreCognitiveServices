using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class TrainingStatusDetails {
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int ExampleCount { get; set; }
        public DateTime TrainingDateTime { get; set; }
        public string FailureReason { get; set; }
    }
}