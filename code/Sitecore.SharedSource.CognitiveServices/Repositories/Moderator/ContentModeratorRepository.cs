extern alias MicrosoftProjectOxfordCommon;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Moderator;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Moderator {
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

        protected HttpContextBase Context { get; set; }

        public ContentModeratorRepository(
            IApiKeys apiKeys,
            HttpContextBase context)
        {
            ApiKeys = apiKeys;
            Context = context;
        }

        public string Evaluate(string imageUrl)
        {
            string token = GetToken();

            var value = SendModeratorPost($"{moderatorUrl}/ProcessImage/Evaluate?CacheImage={imageUrl}", token);

            return value;
        }

        protected string GetToken()
        {
            if (Context.Session[moderateSessionTokenKey] != null)
            {
                var sessionToken = (ModeratorTokenResponse) Context.Session[moderateSessionTokenKey];
                if (sessionToken.Expires_On != null && sessionToken.ExpirationDate >= DateTime.Now)
                    return sessionToken.Access_Token;
            }

            var token = SendTokenRequest();
            Context.Session.Add(moderateSessionTokenKey, token);
            
            return token.Access_Token;
        }

        protected ModeratorTokenResponse SendTokenRequest()
        {
            byte[] reqData = Encoding.UTF8.GetBytes($"resource=https%3A%2F%2Fapi.contentmoderator.cognitive.microsoft.com%2Freview&client_id={ApiKeys.ContentModeratorClientId}&client_secret={ApiKeys.ContentModerator}&grant_type=client_credentials");
            
            WebRequest request = WebRequest.Create("https://login.microsoftonline.com/contentmoderatorprod.onmicrosoft.com/oauth2/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = (long)reqData.Length;
            
            Stream requestStreamAsync = request.GetRequestStream();
            requestStreamAsync.Write(reqData, 0, reqData.Length);
            requestStreamAsync.Close();

            WebResponse responseAsync = request.GetResponse();
            StreamReader streamReader = new StreamReader(responseAsync.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            responseAsync.Close();

            ModeratorTokenResponse t = new JavaScriptSerializer().Deserialize<ModeratorTokenResponse>(end);

            return t;
        }

        protected string SendModeratorPost(string url, string token)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("token");

            byte[] reqData = Encoding.UTF8.GetBytes("");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", ApiKeys.ContentModerator);
            request.Headers.Add("authorization", $"Bearer {token}");
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Method = "POST";
            request.ContentLength = (long)reqData.Length;

            Stream requestStreamAsync = request.GetRequestStream();
            requestStreamAsync.Write(reqData, 0, reqData.Length);
            requestStreamAsync.Close();

            WebResponse responseAsync = request.GetResponse();
            StreamReader streamReader = new StreamReader(responseAsync.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            responseAsync.Close();

            return end;
        }
    }
}