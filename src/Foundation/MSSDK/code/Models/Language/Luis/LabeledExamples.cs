using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class LabeledExamples {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> TokenizedText { get; set; }
        public string IntentLabel { get; set; }
        public List<Entitylabel> EntityLabels { get; set; }
        public List<IntentPrediction> IntentPredictions { get; set; }
        public List<EntityPrediction> EntityPredictions { get; set; }
    }
}