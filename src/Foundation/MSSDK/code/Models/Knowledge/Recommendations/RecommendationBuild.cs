using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class RecommendationBuild
    {
        public int numberOfModelIterations { get; set; }
        public int numberOfModelDimensions { get; set; }
        public int itemCutOffLowerBound { get; set; }
        public int itemCutOffUpperBound { get; set; }
        public int userCutOffLowerBound { get; set; }
        public int userCutOffUpperBound { get; set; }
        public bool enableModelingInsights { get; set; }
        public string splitterStrategy { get; set; }
        public RandomSplitParameters randomSplitterParameters { get; set; }
        public DateSplitParameters dateSplitterParameters { get; set; }
        public int popularItemBenchmarkWindow { get; set; }
        public bool useFeaturesInModel { get; set; }
        public string modelingFeatureList { get; set; }
        public bool allowColdItemPlacement { get; set; }
        public bool enableFeatureCorrelation { get; set; }
        public bool reasoningFeatureList { get; set; }
        public bool enableU2I { get; set; }
    }
}