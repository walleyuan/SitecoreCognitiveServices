extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public class ContentModeratorRepository : TextClient, IContentModeratorRepository
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
        protected static readonly string reviewUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/review/v1.0/teams/";
        protected static readonly string listUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/lists/v1.0/imagelists/";
        protected static readonly string termListUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/lists/v1.0/termlists/";

        protected static readonly string moderateSessionTokenKey = "ModerateSessionTokenKey";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        protected HttpContextBase Context { get; set; }

        public ContentModeratorRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            HttpContextBase context) : base(apiKeys.ContentModerator)
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

        public virtual async Task<EvaluateResponse> EvaluateAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        public async Task<EvaluateResponse> EvaluateAsync(Stream stream)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate", stream);

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Find Faces

        public virtual async Task<FindFacesResponse> FindFacesAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/FindFaces", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        public virtual async Task<FindFacesResponse> FindFacesAsync(Stream stream)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/FindFaces", stream);

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        #endregion Find Faces

        #region Match

        private string GetMatchQuerystring(string listId)
        {
            return string.IsNullOrEmpty(listId) ? "" : $"?listId={listId}";
        }

        public virtual async Task<MatchResponse> MatchAsync(string imageUrl, string listId = "")
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        public virtual async Task<MatchResponse> MatchAsync(Stream stream, string listId = "")
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", stream);

            return JsonConvert.DeserializeObject<MatchResponse>(response);
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

        public virtual async Task<OCRResult> OCRAsync(string imageUrl, string language = "", bool enhanced = false)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        public virtual async Task<OCRResult> OCRAsync(Stream stream, string language = "", bool enhanced = false)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", stream);

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        #endregion OCR

        #region Detect Language

        public virtual async Task<DetectLanguageResponse> DetectLanguageAsync(string text)
        {
            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessText/DetectLanguage", text);

            return JsonConvert.DeserializeObject<DetectLanguageResponse>(response);
        }

        #endregion Detect Language

        #region Screen

        public virtual async Task<ScreenResponse> ScreenAsync(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
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

            return JsonConvert.DeserializeObject<ScreenResponse>(response);
        }

        #endregion Screen

        #endregion Moderate

        #region Review
        
        protected string GetToken()
        { 
            if (Context?.Session?[moderateSessionTokenKey] != null) {
                var sessionToken = (TokenResponse)Context.Session[moderateSessionTokenKey];
                if (sessionToken.Expires_On != null && sessionToken.ExpirationDate >= DateTime.Now)
                    return sessionToken.Access_Token;
            }

            var token = RepositoryClient.SendTokenRequest(ApiKeys.ContentModeratorPrivateKey, ApiKeys.ContentModeratorClientId);
            Context.Session.Add(moderateSessionTokenKey, token);

            return token.Access_Token;
        }

        #region Create Job

        private string GetCreateJobQuerystring(string callbackEndpoint)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(callbackEndpoint))
                sb.Append($"&CallBackEndpoint={callbackEndpoint}");

            return sb.ToString();
        }

        private string GetCreateJobData(string content)
        {
            return $"{{ \"ContentValue\": \"{content}\" }}";
        }

        public virtual async Task<CreateJobResponse> CreateImageJobAsync(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator, 
                $"{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}", 
                GetCreateJobData(imageUrl), 
                "application/json", 
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual async Task<CreateJobResponse> CreateImageJobAsync(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetStreamString(stream),
                RepositoryClient.GetImageStreamContentType(stream),
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual async Task<CreateJobResponse> CreateTextJobAsync(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/jobs?ContentType=Text&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                GetCreateJobData(text),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        #endregion Create Job

        #region Get Job

        public virtual async Task<GetJobResponse> GetJobAsync(string teamName, string jobId)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/jobs/{jobId}", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetJobResponse>(response);
        }

        #endregion Get Job

        #region Create Review

        public virtual async Task<List<string>> CreateReviewAsync(string teamName, List<ReviewRequest> requests, string subTeam = "")
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(subTeam))
                sb.Append($"?subTeam={subTeam}");
            
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/reviews{sb}",
                JsonConvert.SerializeObject(requests),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        #endregion Create Review

        #region Get Review

        public virtual async Task<GetReviewResponse> GetReviewAsync(string teamName, string reviewId)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/reviews/{reviewId}", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetReviewResponse>(response);
        }

        #endregion Get Review

        #region Create or Update Workflow

        public virtual async Task CreateOrUpdateWorkflowAsync(string teamName, string workflowName, WorkflowExpression expression)
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/workflows/{workflowName}",
                JsonConvert.SerializeObject(expression),
                "application/json",
                "PUT",
                GetToken());
        }

        #endregion Create or Update Workflow

        #region Get Workflow

        public virtual async Task<WorkflowExpression> GetWorkflowAsync(string teamName, string workflowName)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/workflows/{workflowName}", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<WorkflowExpression>(response);
        }

        public virtual async Task<List<WorkflowExpression>> GetAllWorkflowsAsync(string teamName)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/workflows", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<List<WorkflowExpression>>(response);
        }

        #endregion Get Workflow

        #endregion Review

        #region List Management

        #region Image

        private string GetAddImageQuerystring(ContentModeratorTag tag, string label)
        {
            StringBuilder sb = new StringBuilder();
            if (tag != ContentModeratorTag.None)
                sb.Append($"?tag={Enum.GetName(typeof(ContentModeratorTag), tag)}");

            if (!string.IsNullOrEmpty(label))
            {
                var concat = sb.Length > 0 ? "&" : "?";
                sb.Append($"{concat}label={label}");
            }

            return sb.ToString();
        }

        public virtual async Task AddImageAsync(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            string data = $"{{ \"DataRepresentation\":\"URL\", \"Value\":\"{imageUrl}\" }}";
            
            await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/images{GetAddImageQuerystring(tag, label)}", data);
        }

        public virtual async Task AddImageAsync(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/images{GetAddImageQuerystring(tag, label)}", stream);
        }

        public virtual async Task DeleteImageAsync(string listId, string imageId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/images/{imageId}");
        }

        public virtual async Task DeleteAllImageAsync(string listId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/images");
        }

        public virtual async Task<List<string>> GetAllImageIdsAsync(string listId)
        {
            var response = await SendGetAsync($"{listUrl}{listId}/images");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        #endregion Image

        #region Image Lists

        public virtual async Task<string> GetImageListDetailsAsync(string listId)
        {
            var response = await SendGetAsync($"{listUrl}{listId}");

            return response;
        }

        public virtual async Task<string> CreateListAsync(ListDetails details)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{listUrl}", JsonConvert.SerializeObject(details));

            return response;
        }

        public virtual async Task DeleteImageListAsync(string listId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}");
        }

        public virtual async Task<string> GetAllImageListsAsync()
        {
            var response = await SendGetAsync(listUrl);

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task<string> RefreshImageSearchIndexAsync(string listId)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/RefreshIndex", "");

            return response;
        }

        public virtual async Task UpdateImageListDetailsAsync(string listId, ListDetails details)
        {
            await RepositoryClient.SendJsonPutAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}", JsonConvert.SerializeObject(details));
        }

        #endregion Image Lists

        #region Term

        public virtual async Task<string> AddTermAsync(string listId, string term, string language)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{termListUrl}{listId}/terms/{term}?language={language}", "");

            return response;
        }

        public virtual async Task DeleteTermAsync(string listId, string term, string language)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/terms/{term}?language={language}");
        }

        public virtual async Task DeleteAllTermsAsync(string listId, string language)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{listUrl}{listId}/terms?language={language}");
        }

        public virtual async Task<string> GetAllTermsAsync(string listId, string language)
        {
            var response = await SendGetAsync($"{termListUrl}{listId}/terms?language={language}");

            return JsonConvert.DeserializeObject<string>(response);
        }

        #endregion Term

        #region Term Lists

        public virtual async Task<string> CreateTextListAsync(ListDetails details)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, termListUrl, JsonConvert.SerializeObject(details));

            return response;
        }

        public virtual async Task DeleteTermListAsync(string listId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{termListUrl}{listId}");
        }

        public virtual async Task<string> GetAllTermListsAsync()
        {
            var response = await SendGetAsync(termListUrl);

            return response;
        }

        public virtual async Task<string> GetTermListDetailsAsync(string listId)
        {
            var response = await SendGetAsync($"{termListUrl}{listId}");

            return response;
        }

        public virtual async Task<string> RefreshTermSearchIndexAsync(string listId, string language)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{termListUrl}{listId}/RefreshIndex?lanaguage={language}", "");

            return response;
        }

        public virtual async Task UpdateTermListDetailsAsync(string listId, ListDetails details)
        {
            await RepositoryClient.SendJsonPutAsync(ApiKeys.ContentModerator, $"{termListUrl}{listId}", JsonConvert.SerializeObject(details));
        }

        #endregion Term Lists

        #endregion List Management
    }
}