using System.IO;
using Sitecore.SharedSource.CognitiveServices.Models.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IContentModeratorService
    {
        ContentModeratorEvaluateResponse Evaluate(string imageUrl);
        ContentModeratorEvaluateResponse Evaluate(Stream stream);
        ContentModeratorFindFacesResponse FindFaces(string imageUrl);
        ContentModeratorFindFacesResponse FindFaces(Stream stream);
        ContentModeratorMatchResponse Match(string imageUrl, string listId = "");
        ContentModeratorMatchResponse Match(Stream stream, string listId = "");
        ContentModeratorOCRResult OCR(string imageUrl, string language = "", bool enhanced = false);
        ContentModeratorOCRResult OCR(Stream stream, string language = "", bool enhanced = false);
        ContentModeratorDetectLanguageResponse DetectLanguage(string text);
        ContentModeratorScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "");
    }
}