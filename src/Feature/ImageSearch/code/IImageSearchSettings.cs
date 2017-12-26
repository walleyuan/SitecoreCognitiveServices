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
    }
}
