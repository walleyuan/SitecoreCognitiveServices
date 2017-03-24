using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class LabeledExamples {
        public int Id { get; set; }
        public string Text { get; set; }
        public string[] TokenizedText { get; set; }
        public string IntentLabel { get; set; }
        public Entitylabel[] EntityLabels { get; set; }
        public IntentPrediction[] IntentPredictions { get; set; }
        public EntityPrediction[] EntityPredictions { get; set; }
    }
}