namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Setup
{
    public class SetupInformation : ISetupInformation
    {
        public string FaceApiKey { get; set; }
        public string EmotionApiKey { get; set; }
        public string TextAnalyticsApiKey { get; set; }
        public string ComputerVisionApiKey { get; set; }
    }
}