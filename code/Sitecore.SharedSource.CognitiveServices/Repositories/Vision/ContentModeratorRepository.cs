extern alias MicrosoftProjectOxfordCommon;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public class ContentModeratorRepository : IContentModeratorRepository
    {
        //documentation
        //https://www.microsoft.com/cognitive-services/en-us/content-moderator/documentation/review-api-authentication#request-samples
        //moderate
        //https://westus.dev.cognitive.microsoft.com/docs/services/57cf753a3f9b070c105bd2c1/operations/57cf753a3f9b070868a1f66c/console
        //review
        //https://westus.dev.cognitive.microsoft.com/docs/services/580519463f9b070e5c591178/operations/580519483f9b0709fc47f9c5
        //list management
        //https://westus.dev.cognitive.microsoft.com/docs/services/57cf755e3f9b070c105bd2c2/operations/57cf755e3f9b070868a1f675

        protected static readonly string moderatorUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0";
        
        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        protected HttpContextBase Context { get; set; }

        public ContentModeratorRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            HttpContextBase context)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
            Context = context;
        }

        #region Moderate

        #region Evaluate

        private string GetImageUrlData(string imageUrl)
        {
            return $"{{\"DataRepresentation\":\"URL\",\"Value\":\"{imageUrl}\"}}";
        }

        public async Task<ContentModeratorEvaluateResponse> EvaluateAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<ContentModeratorEvaluateResponse>(response);
        }

        public async Task<ContentModeratorEvaluateResponse> EvaluateAsync(Stream stream)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate", stream);

            return JsonConvert.DeserializeObject<ContentModeratorEvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Find Faces

        public async Task<ContentModeratorFindFacesResponse> FindFacesAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/FindFaces", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<ContentModeratorFindFacesResponse>(response);
        }

        public async Task<ContentModeratorFindFacesResponse> FindFacesAsync(Stream stream)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/FindFaces", stream);

            return JsonConvert.DeserializeObject<ContentModeratorFindFacesResponse>(response);
        }

        #endregion Find Faces

        #region Match

        private string GetMatchQuerystring(string listId)
        {
            return string.IsNullOrEmpty(listId) ? "" : $"?listId={listId}";
        }

        public async Task<ContentModeratorMatchResponse> MatchAsync(string imageUrl, string listId = "")
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<ContentModeratorMatchResponse>(response);
        }

        public async Task<ContentModeratorMatchResponse> MatchAsync(Stream stream, string listId = "")
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", stream);

            return JsonConvert.DeserializeObject<ContentModeratorMatchResponse>(response);
        }

        #endregion Match

        #region OCR

        private string GetOCRQuerystring(string language, bool enhanced)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(language))
                sb.Append($"?language={language}");

            if (enhanced)
            {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}enhanced={enhanced}");
            }

            return sb.ToString();
        }

        public async Task<ContentModeratorOCRResult> OCRAsync(string imageUrl, string language = "", bool enhanced = false)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<ContentModeratorOCRResult>(response);
        }

        public async Task<ContentModeratorOCRResult> OCRAsync(Stream stream, string language = "", bool enhanced = false)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", stream);

            return JsonConvert.DeserializeObject<ContentModeratorOCRResult>(response);
        }

        #endregion OCR

        #region Detect Language

        public async Task<ContentModeratorDetectLanguageResponse> DetectLanguageAsync(string text)
        {
            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessText/DetectLanguage", text);

            return JsonConvert.DeserializeObject<ContentModeratorDetectLanguageResponse>(response);
        }

        #endregion Detect Language

        #region Screen

        public async Task<ContentModeratorScreenResponse> ScreenAsync(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?language={language}");

            if (autocorrect)
                sb.Append($"&autocorrect={autocorrect}");

            if (urls)
                sb.Append($"&urls={urls}");

            if (PII)
                sb.Append($"&PII={PII}");

            if (!string.IsNullOrEmpty(listId))
                sb.Append($"&listId={listId}");

            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessText/Screen{sb}", text);

            return JsonConvert.DeserializeObject<ContentModeratorScreenResponse>(response);
        }

        #endregion Screen

        #endregion Moderate

        #region Review

        #endregion Review

        #region List Management

        #endregion List Management
    }
}