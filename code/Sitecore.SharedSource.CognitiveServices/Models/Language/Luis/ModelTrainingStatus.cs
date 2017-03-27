using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ModelTrainingStatus {
        public string ModelId { get; set; }
        public TrainingStatusDetails Details { get; set; }
    }
}