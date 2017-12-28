using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public interface IImageSearchSettings {
        string SitecoreIndexNameFormat { get; }
        string CognitiveIndexNameFormat { get; }
        string ImageAnalysisFolder { get; }
        string ImageAnalysisTemplate { get; }
        string VisualAnalysisField { get; }
        string TextualAnalysisField { get; }
        string FacialAnalysisField { get; }
        string EmotionalAnalysisField { get; }
    }
}
