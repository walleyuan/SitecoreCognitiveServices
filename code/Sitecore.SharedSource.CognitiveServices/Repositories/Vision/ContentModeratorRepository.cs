extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public class ContentModeratorRepository : IContentModeratorRepository
    {
        //so far this doesn't work. The token can be retrieved but the actual request has not yet accepted my token or api key. There may be more to the request than is documented. 
        //documentation
        //https://www.microsoft.com/cognitive-services/en-us/content-moderator/documentation/review-api-authentication#request-samples
        //sdk
        //https://github.com/MicrosoftContentModerator/Microsoft.CognitiveServices.ContentModerator-Windows/blob/master/ContentModeratorSDK/ModeratorClient.cs
        //moderate
        //https://westus.dev.cognitive.microsoft.com/docs/services/57cf753a3f9b070c105bd2c1/operations/57cf753a3f9b070868a1f66c/console
        //review
        //https://westus.dev.cognitive.microsoft.com/docs/services/580519463f9b070e5c591178/operations/580519483f9b0709fc47f9c5
        //list management
        //https://westus.dev.cognitive.microsoft.com/docs/services/57cf755e3f9b070c105bd2c2/operations/57cf755e3f9b070868a1f675

        protected static readonly string moderatorUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0";
        protected static readonly string moderateSessionTokenKey = "ModerateSessionTokenKey";

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

        public string Evaluate(string imageUrl)
        {
            string token = GetToken();

            var value = RepositoryClient.SendTokenPost(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate?CacheImage={imageUrl}", token);

            return value;
        }

        protected string GetToken()
        {
            if (Context.Session[moderateSessionTokenKey] != null)
            {
                var sessionToken = (TokenResponse) Context.Session[moderateSessionTokenKey];
                if (sessionToken.Expires_On != null && sessionToken.ExpirationDate >= DateTime.Now)
                    return sessionToken.Access_Token;
            }

            var token = RepositoryClient.SendTokenRequest(ApiKeys.ContentModerator, ApiKeys.ContentModeratorClientId);
            Context.Session.Add(moderateSessionTokenKey, token);
            
            return token.Access_Token;
        }
    }
}