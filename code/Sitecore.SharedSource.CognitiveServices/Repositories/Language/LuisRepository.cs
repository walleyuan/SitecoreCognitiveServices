using Microsoft.ProjectOxford.Text.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language {
    public class LuisRepository : TextClient, ILuisRepository {

        protected static readonly string luisUrl = "https://westus.api.cognitive.microsoft.com/luis/api/v2.0/apps/";

        protected readonly IRepositoryClient RepositoryClient;

        public LuisRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.Luis) {

            RepositoryClient = repoClient;
        }

        #region Apps

        public virtual async Task<string> AddApplicationAsync(AddApplicationRequest request)
        {
            var response = await SendPostAsync(luisUrl, JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task DeleteApplicationAsync(string appId)
        {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}");
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