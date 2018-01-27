namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Setup
{
    public interface ISetupInformation
    {        
        string FaceApiKey { get; set; }
        string EmotionApiKey { get; set; }
        string TextAnalyticsApiKey { get; set; }
        string ComputerVisionApiKey { get; set; }
    }
}