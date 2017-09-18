using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator;
using System.Linq;
using Chronic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Vision {
    public class ContentModeratorRepository : IContentModeratorRepository
    {
        protected static readonly string moderatorUrl = "moderate/v1.0";
        protected static readonly string reviewUrl = "review/v1.0/teams/";
        protected static readonly string listUrl = "lists/v1.0/imagelists/";
        protected static readonly string termListUrl = "lists/v1.0/termlists/";

        protected static readonly string moderateSessionTokenKey = "ModerateSessionTokenKey";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        protected HttpContextBase Context { get; set; }

        public ContentModeratorRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            HttpContextBase context) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
            Context = context;
        }

        #region Moderate

        #region Evaluate

        protected virtual string GetImageUrlData(string imageUrl)
        {
            return JsonConvert.SerializeObject(new AddImageRequest() {Value = imageUrl});
        }

        public virtual EvaluateResponse Evaluate(string imageUrl) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Evaluate", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        public virtual async Task<EvaluateResponse> EvaluateAsync(string imageUrl) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Evaluate", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        public EvaluateResponse Evaluate(Stream stream) {
            var response = RepositoryClient.SendImagePost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Evaluate", stream);

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        public async Task<EvaluateResponse> EvaluateAsync(Stream stream) {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Evaluate", stream);

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Find Faces

        public virtual FindFacesResponse FindFaces(string imageUrl) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/FindFaces", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        public virtual async Task<FindFacesResponse> FindFacesAsync(string imageUrl) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/FindFaces", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        public virtual FindFacesResponse FindFaces(Stream stream) {
            var response = RepositoryClient.SendImagePost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/FindFaces", stream);

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        public virtual async Task<FindFacesResponse> FindFacesAsync(Stream stream) {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/FindFaces", stream);

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        #endregion Find Faces

        #region Match

        protected virtual string GetMatchQuerystring(string listId) {
            return string.IsNullOrEmpty(listId) ? "" : $"?listId={listId}";
        }

        public virtual MatchResponse Match(string imageUrl, string listId = "") {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        public virtual async Task<MatchResponse> MatchAsync(string imageUrl, string listId = "") {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        public virtual MatchResponse Match(Stream stream, string listId = "") {
            var response = RepositoryClient.SendImagePost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", stream);

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        public virtual async Task<MatchResponse> MatchAsync(Stream stream, string listId = "") {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", stream);

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        #endregion Match

        #region OCR

        protected virtual string GetOCRQuerystring(string language, bool enhanced) {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(language))
                sb.Append($"?language={language}");

            if (enhanced) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}enhanced={enhanced}");
            }

            return sb.ToString();
        }

        public virtual OCRResult OCR(string imageUrl, string language = "", bool enhanced = false) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        public virtual async Task<OCRResult> OCRAsync(string imageUrl, string language = "", bool enhanced = false) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        public virtual OCRResult OCR(Stream stream, string language = "", bool enhanced = false) {
            var response = RepositoryClient.SendImagePost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", stream);

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        public virtual async Task<OCRResult> OCRAsync(Stream stream, string language = "", bool enhanced = false) {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", stream);

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        #endregion OCR

        #region Detect Language

        public virtual DetectLanguageResponse DetectLanguage(string text) {
            var response = RepositoryClient.SendTextPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessText/DetectLanguage", text);

            return JsonConvert.DeserializeObject<DetectLanguageResponse>(response);
        }

        public virtual async Task<DetectLanguageResponse> DetectLanguageAsync(string text) {
            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessText/DetectLanguage", text);

            return JsonConvert.DeserializeObject<DetectLanguageResponse>(response);
        }

        #endregion Detect Language

        #region Screen

        protected virtual string GetScreenQuerystring(string language, bool autocorrect, bool urls, bool PII, string listId)
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

            return sb.ToString();
        }

        public virtual ScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "") {
            var qs = GetScreenQuerystring(language, autocorrect, urls, PII, listId);
            var response = RepositoryClient.SendTextPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessText/Screen{qs}", text);

            return JsonConvert.DeserializeObject<ScreenResponse>(response);
        }

        public virtual async Task<ScreenResponse> ScreenAsync(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
        {
            var qs = GetScreenQuerystring(language, autocorrect, urls, PII, listId);
            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{moderatorUrl}/ProcessText/Screen{qs}", text);

            return JsonConvert.DeserializeObject<ScreenResponse>(response);
        }

        #endregion Screen

        #endregion Moderate

        #region Review

        protected virtual string GetToken() {
            if (Context?.Session?[moderateSessionTokenKey] != null) {
                var sessionToken = (TokenResponse)Context.Session[moderateSessionTokenKey];
                if (sessionToken.Expires_On != null && sessionToken.ExpirationDate >= DateTime.Now)
                    return sessionToken.Access_Token;
            }

            var token = RepositoryClient.SendContentModeratorTokenRequest(ApiKeys.ContentModeratorPrivateKey, ApiKeys.ContentModeratorClientId);
            Context.Session.Add(moderateSessionTokenKey, token);

            return token.Access_Token;
        }

        #region Create Job

        protected virtual string GetCreateJobQuerystring(string callbackEndpoint) {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(callbackEndpoint))
                sb.Append($"&CallBackEndpoint={callbackEndpoint}");

            return sb.ToString();
        }
        
        public virtual CreateJobResponse CreateImageJob(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "") {
            var response = RepositoryClient.Send(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetByteArray(JsonConvert.SerializeObject(new JobRequest { ContentValue = imageUrl })),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual async Task<CreateJobResponse> CreateImageJobAsync(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "") {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetByteArray(JsonConvert.SerializeObject(new JobRequest { ContentValue = imageUrl })),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual CreateJobResponse CreateImageJob(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "") {
            var response = RepositoryClient.Send(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetByteArray(stream),
                RepositoryClient.GetImageStreamContentType(stream),
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual async Task<CreateJobResponse> CreateImageJobAsync(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "") {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetByteArray(stream),
                RepositoryClient.GetImageStreamContentType(stream),
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual CreateJobResponse CreateTextJob(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "") {
            var response = RepositoryClient.Send(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs?ContentType=Text&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetByteArray(JsonConvert.SerializeObject(new JobRequest { ContentValue = text })),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public virtual async Task<CreateJobResponse> CreateTextJobAsync(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "") {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs?ContentType=Text&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetByteArray(JsonConvert.SerializeObject(new JobRequest { ContentValue = text })),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }
        
        #endregion Create Job

        #region Get Job

        public virtual GetJobResponse GetJob(string teamName, string jobId) {
            var response = RepositoryClient.Send(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs/{jobId}", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetJobResponse>(response);
        }

        public virtual async Task<GetJobResponse> GetJobAsync(string teamName, string jobId) {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/jobs/{jobId}", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetJobResponse>(response);
        }

        #endregion Get Job

        #region Create Review

        public virtual List<string> CreateReview(string teamName, List<ReviewRequest> requests, string subTeam = "") {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(subTeam))
                sb.Append($"?subTeam={subTeam}");
            
            var response = RepositoryClient.Send(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/reviews{sb}",
                RepositoryClient.GetByteArray(JsonConvert.SerializeObject(requests)),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<List<string>> CreateReviewAsync(string teamName, List<ReviewRequest> requests, string subTeam = "") {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(subTeam))
                sb.Append($"?subTeam={subTeam}");

            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/reviews{sb}",
                RepositoryClient.GetByteArray(JsonConvert.SerializeObject(requests)),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        #endregion Create Review

        #region Get Review

        public virtual GetReviewResponse GetReview(string teamName, string reviewId) {
            var response = RepositoryClient.Send(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/reviews/{reviewId}", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetReviewResponse>(response);
        }

        public virtual async Task<GetReviewResponse> GetReviewAsync(string teamName, string reviewId) {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/reviews/{reviewId}", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetReviewResponse>(response);
        }

        #endregion Get Review

        #region Create or Update Workflow

        public virtual bool CreateOrUpdateWorkflow(string teamName, string workflowName, WorkflowExpression expression) {
            var data = JsonConvert.SerializeObject(expression);

            var response = RepositoryClient.Send(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/workflows/{workflowName}",
                RepositoryClient.GetByteArray(data),
                "application/json",
                "PUT",
                GetToken());

            return JsonConvert.DeserializeObject<bool>(response);
        }

        public virtual async Task<bool> CreateOrUpdateWorkflowAsync(string teamName, string workflowName, WorkflowExpression expression) {
            var data = JsonConvert.SerializeObject(expression);

            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/workflows/{workflowName}",
                RepositoryClient.GetByteArray(data),
                "application/json",
                "PUT",
                GetToken());

            return JsonConvert.DeserializeObject<bool>(response);
        }

        #endregion Create or Update Workflow

        #region Get Workflow

        public virtual WorkflowExpressionResponse GetWorkflow(string teamName, string workflowName) {
            var response = RepositoryClient.Send(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/workflows/{workflowName}", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<WorkflowExpressionResponse>(response);
        }

        public virtual async Task<WorkflowExpressionResponse> GetWorkflowAsync(string teamName, string workflowName) {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/workflows/{workflowName}", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<WorkflowExpressionResponse>(response);
        }

        public virtual List<WorkflowExpressionResponse> GetAllWorkflows(string teamName) {
            var response = RepositoryClient.Send(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/workflows", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<List<WorkflowExpressionResponse>>(response);
        }

        public virtual async Task<List<WorkflowExpressionResponse>> GetAllWorkflowsAsync(string teamName) {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{reviewUrl}{teamName}/workflows", null, "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<List<WorkflowExpressionResponse>>(response);
        }

        #endregion Get Workflow

        #endregion Review

        #region List Management

        #region Image

        protected virtual string GetAddImageQuerystring(ContentModeratorTag tag, string label) {
            StringBuilder sb = new StringBuilder();
            if (tag != ContentModeratorTag.None)
                sb.Append($"?tag={(int)tag}");

            if (!string.IsNullOrEmpty(label)) {
                var concat = sb.Length > 0 ? "&" : "?";
                sb.Append($"{concat}label={label}");
            }

            return sb.ToString();
        }

        public virtual AddImageResponse AddImage(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "") {
            
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images{GetAddImageQuerystring(tag, label)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<AddImageResponse>(response);
        }

        public virtual async Task<AddImageResponse> AddImageAsync(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            var request = new AddImageRequest() {Value = imageUrl};
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images{GetAddImageQuerystring(tag, label)}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<AddImageResponse>(response);
        }

        public virtual AddImageResponse AddImage(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "") {
            var response = RepositoryClient.SendImagePost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images{GetAddImageQuerystring(tag, label)}", stream);

            return JsonConvert.DeserializeObject<AddImageResponse>(response);
        }

        public virtual async Task<AddImageResponse> AddImageAsync(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "") {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images{GetAddImageQuerystring(tag, label)}", stream);

            return JsonConvert.DeserializeObject<AddImageResponse>(response);
        }

        public virtual void DeleteImage(string listId, string imageId) {
            RepositoryClient.SendJsonDelete(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images/{imageId}");
        }

        public virtual async Task DeleteImageAsync(string listId, string imageId) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images/{imageId}");
        }

        public virtual void DeleteAllImage(string listId) {
            RepositoryClient.SendJsonDelete(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images");
        }

        public virtual async Task DeleteAllImageAsync(string listId) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images");
        }

        public virtual GetImagesResponse GetAllImageIds(string listId) {
            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images");

            return JsonConvert.DeserializeObject<GetImagesResponse>(response);
        }

        public virtual async Task<GetImagesResponse> GetAllImageIdsAsync(string listId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/images");

            return JsonConvert.DeserializeObject<GetImagesResponse>(response);
        }

        #endregion Image

        #region Image Lists

        public virtual ListDetails GetImageListDetails(string listId) {
            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}");

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual async Task<ListDetails> GetImageListDetailsAsync(string listId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}");

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual ListDetails CreateList(ListDetails details) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}", JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual async Task<ListDetails> CreateListAsync(ListDetails details) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}", JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual void DeleteImageList(string listId) {
            RepositoryClient.SendJsonDelete(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}");
        }

        public virtual async Task DeleteImageListAsync(string listId) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}");
        }

        public virtual List<ListDetails> GetAllImageLists() {
            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, listUrl);

            return JsonConvert.DeserializeObject<List<ListDetails>>(response);
        }

        public virtual async Task<List<ListDetails>> GetAllImageListsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, listUrl);

            return JsonConvert.DeserializeObject<List<ListDetails>>(response);
        }

        public virtual RefreshSearchResponse RefreshImageSearchIndex(string listId) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/RefreshIndex", "");

            return JsonConvert.DeserializeObject<RefreshSearchResponse>(response);
        }

        public virtual async Task<RefreshSearchResponse> RefreshImageSearchIndexAsync(string listId) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/RefreshIndex", "");

            return JsonConvert.DeserializeObject<RefreshSearchResponse>(response);
        }

        public virtual ListDetails UpdateImageListDetails(string listId, ListDetails details) {
            var response = RepositoryClient.SendJsonPut(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}", JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual async Task<ListDetails> UpdateImageListDetailsAsync(string listId, ListDetails details) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}", JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        #endregion Image Lists

        #region Term

        public virtual void AddTerm(string listId, string term, string language) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}/terms/{term}?language={language}", "");
        }

        public virtual async Task AddTermAsync(string listId, string term, string language) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}/terms/{term}?language={language}", "");
        }

        public virtual void DeleteTerm(string listId, string term, string language) {
            RepositoryClient.SendJsonDelete(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/terms/{term}?language={language}");
        }

        public virtual async Task DeleteTermAsync(string listId, string term, string language) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/terms/{term}?language={language}");
        }

        public virtual void DeleteAllTerms(string listId, string language) {
            RepositoryClient.SendJsonDelete(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/terms?language={language}");
        }

        public virtual async Task DeleteAllTermsAsync(string listId, string language) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{listUrl}{listId}/terms?language={language}");
        }

        public virtual GetTermsResponse GetAllTerms(string listId, string language) {
            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}/terms?language={language}");

            return JsonConvert.DeserializeObject<GetTermsResponse>(response);
        }

        public virtual async Task<GetTermsResponse> GetAllTermsAsync(string listId, string language) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}/terms?language={language}");

            return JsonConvert.DeserializeObject<GetTermsResponse>(response);
        }

        #endregion Term

        #region Term Lists

        public virtual ListDetails CreateTermList(ListDetails details) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, termListUrl, JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual async Task<ListDetails> CreateTermListAsync(ListDetails details) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, termListUrl, JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual void DeleteTermList(string listId) {
            RepositoryClient.SendJsonDelete(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}");
        }

        public virtual async Task DeleteTermListAsync(string listId) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}");
        }

        public virtual List<ListDetails> GetAllTermLists() {
            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, termListUrl);

            return JsonConvert.DeserializeObject<List<ListDetails>>(response);
        }

        public virtual async Task<List<ListDetails>> GetAllTermListsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, termListUrl);

            return JsonConvert.DeserializeObject<List<ListDetails>>(response);
        }

        public virtual ListDetails GetTermListDetails(string listId) {
            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}");

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual async Task<ListDetails> GetTermListDetailsAsync(string listId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}");

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual RefreshSearchResponse RefreshTermSearchIndex(string listId, string language) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}/RefreshIndex?lanaguage={language}", "");

            return JsonConvert.DeserializeObject<RefreshSearchResponse>(response);
        }

        public virtual async Task<RefreshSearchResponse> RefreshTermSearchIndexAsync(string listId, string language) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}/RefreshIndex?lanaguage={language}", "");

            return JsonConvert.DeserializeObject<RefreshSearchResponse>(response);
        }

        public virtual ListDetails UpdateTermListDetails(string listId, ListDetails details) {
            var response = RepositoryClient.SendJsonPut(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}", JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        public virtual async Task<ListDetails> UpdateTermListDetailsAsync(string listId, ListDetails details) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.ContentModerator, $"{ApiKeys.ContentModeratorEndpoint}{termListUrl}{listId}", JsonConvert.SerializeObject(details));

            return JsonConvert.DeserializeObject<ListDetails>(response);
        }

        #endregion Term Lists

        #endregion List Management
    }
}