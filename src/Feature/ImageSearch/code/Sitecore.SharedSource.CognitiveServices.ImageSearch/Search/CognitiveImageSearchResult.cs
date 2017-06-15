using System.Collections.Generic;
using Sitecore.ContentSearch;
using Microsoft.ProjectOxford.Vision.Contract;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Web.Script.Serialization;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public class CognitiveImageSearchResult : SearchResultItem, ICognitiveImageSearchResult {

        #region properties
        
        [IndexField("EmotionAnalysis")]
        public string EmotionAnalysisValue { get; set; }

        public Emotion[] EmotionAnalysis => SaturateValue<Emotion[]>(EmotionAnalysisValue) ?? new Emotion[0];

        [IndexField("FacialAnalysis")]
        public string FacialAnalysisValue { get; set; }

        public Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis => SaturateValue<Microsoft.ProjectOxford.Face.Contract.Face[]>(FacialAnalysisValue) ?? new Microsoft.ProjectOxford.Face.Contract.Face[0];

        [IndexField("TextAnalysis")]
        public string TextAnalysisValue { get; set; }

        public OcrResults TextAnalysis => SaturateValue<OcrResults>(TextAnalysisValue) ?? new OcrResults();

        [IndexField("VisionAnalysis")]
        public string VisionAnalysisValue { get; set; }

        public AnalysisResult VisionAnalysis => SaturateValue<AnalysisResult>(VisionAnalysisValue) ?? new AnalysisResult();
        
        [IndexField("_uniqueid")]
        public string UniqueId { get; set; }
        
        [IndexField("gender")]
        public int Gender { get; set; }

        [IndexField("size")]
        public int Size { get; set; }

        [IndexField("glasses")]
        public List<int> Glasses { get; set; }

        [IndexField("Tags")]
        public string[] Tags { get; set; }

        [IndexField("AgeMin")]
        public double AgeMin { get; set; }

        [IndexField("AgeMax")]
        public double AgeMax { get; set; }

        #endregion properties

        private static T SaturateValue<T>(string value) {
            if (string.IsNullOrEmpty(value))
                return default(T);

            try {
                return new JavaScriptSerializer().Deserialize<T>(value);
            } catch { }

            return default(T);
        }
    }
}