using Microsoft.ProjectOxford.Text.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language {
    public class LuisRepository : TextClient, ILuisRepository {

        protected static readonly string luisUrl = "https://westus.api.cognitive.microsoft.com/luis/api/v2.0/apps/";

        protected readonly IRepositoryClient RepositoryClient;
        protected readonly ICSVParser CSVParser;

        public LuisRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            ICSVParser csvParser)
            : base(apiKeys.Luis) {

            RepositoryClient = repoClient;
            CSVParser = csvParser;
        }

        #region Apps

        public virtual async Task<string> AddApplicationAsync(AddApplicationRequest request) {
            var response = await SendPostAsync(luisUrl, JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task DeleteApplicationAsync(string appId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}");
        }

        public virtual async Task<List<List<string>>> DownloadApplicationQueryLogsAsync(string appId) {
            var response = await SendGetAsync($"{luisUrl}{appId}/querylogs");

            return CSVParser.ParseCSV(response);
        }

        public virtual async Task<List<ApplicationCulture>> GetApplicationCulturesAsync() {
            var response = await SendGetAsync($"{luisUrl}cultures");

            return JsonConvert.DeserializeObject<List<ApplicationCulture>>(response);
        }

        public virtual async Task<List<string>> GetApplicationDomainsAsync() {
            var response = await SendGetAsync($"{luisUrl}domains");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<ApplicationInfo> GetApplicationInfoAsync(string appId) {
            var response = await SendGetAsync($"{luisUrl}{appId}");

            return JsonConvert.DeserializeObject<ApplicationInfo>(response);
        }

        public virtual async Task<List<string>> GetApplicationUsageScenariosAsync() {
            var response = await SendGetAsync($"{luisUrl}usagescenarios");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<PersonalAssistantResponse> GetPersonalAssistantApplicationsAsync() {
            var response = await SendGetAsync($"{luisUrl}assistants");

            return JsonConvert.DeserializeObject<PersonalAssistantResponse>(response);
        }

        public virtual async Task<List<UserApplication>> GetUserApplicationsAsync(int skip = 0, int take = 100) {
            StringBuilder sb = new StringBuilder();
            if (skip > 0)
                sb.Append($"?skip={skip}");

            if (take != 100) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}take={take}");
            }

            var response = await SendGetAsync($"{luisUrl}{sb}");

            return JsonConvert.DeserializeObject<List<UserApplication>>(response);
        }

        public virtual async Task<string> ImportApplicationAsync(ImportApplicationRequest request, string appName = "") {
            var appQS = string.IsNullOrEmpty(appName) ? "" : $"?appName={appName}";

            var response = await SendPostAsync($"{luisUrl}import{appQS}", JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task<PublishResponse> PublishApplicationAsync(string appId, PublishRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/publish", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<PublishResponse>(response);
        }

        public virtual async Task RenameApplication(string appId, ApplicationRenameRequest request) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKey, $"{luisUrl}{appId}", JsonConvert.SerializeObject(request));
        }
        
        #endregion Apps

        #region Examples

        #endregion Examples

        #region Features

        #endregion Features

        #region Models

        #endregion Models

        #region Train

        #endregion Train

        #region User

        #endregion User

        #region Versions

        #endregion Versions
    }
}