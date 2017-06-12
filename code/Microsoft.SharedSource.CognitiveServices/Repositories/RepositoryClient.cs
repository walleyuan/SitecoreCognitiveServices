using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models;
using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Repositories
{
    public class RepositoryClient : IRepositoryClient
    {
        public virtual async Task<string> SendGetAsync(string apiKey, string url) {
            return await SendAsync(apiKey, url, "", "application/json", "GET");
        }

        public virtual string SendGet(string apiKey, string url) {
            return Send(apiKey, url, "", "application/json", "GET");
        }

        public virtual async Task<string> SendPostMultiPartAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, data, "multipart/form-data", "POST");
        }

        public virtual string SendPostMultiPart(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "multipart/form-data", "POST");
        }

        public virtual async Task<string> SendEncodedFormPostAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, data, "application/x-www-form-urlencoded", "POST");
        }

        public virtual string SendEncodedFormPost(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "application/x-www-form-urlencoded", "POST");
        }

        public virtual async Task<string> SendTextPostAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, data, "text/plain", "POST");
        }

        public virtual string SendTextPost(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "text/plain", "POST");
        }

        public virtual async Task<string> SendJsonPostAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, data, "application/json", "POST");
        }

        public virtual string SendJsonPost(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "application/json", "POST");
        }

        public virtual async Task<string> SendJsonPutAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, data, "application/json", "PUT");
        }

        public virtual string SendJsonPut(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "application/json", "PUT");
        }

        public virtual async Task<string> SendJsonPatchAsync(string apiKey, string url, string data) {
            return await SendAsync(apiKey, url, data, "application/json", "PATCH");
        }

        public virtual string SendJsonPatch(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "application/json", "PATCH");
        }

        public virtual async Task<string> SendJsonDeleteAsync(string apiKey, string url)
        {
            return await SendAsync(apiKey, url, "", "application/json", "DELETE");
        }

        public virtual string SendJsonDelete(string apiKey, string url) {
            return Send(apiKey, url, "", "application/json", "DELETE");
        }

        public virtual async Task<string> SendOctetStreamUpdateAsync(string apiKey, string url, Stream stream)
        {
            return await SendAsync(apiKey, url, GetStreamString(stream), "application/octet-stream", "UPDATE");
        }

        public virtual string SendOctetStreamUpdate(string apiKey, string url, Stream stream) {
            return Send(apiKey, url, GetStreamString(stream), "application/octet-stream", "UPDATE");
        }

        public virtual async Task<string> SendOctetStreamPostAsync(string apiKey, string url, Stream stream)
        {
            return await SendAsync(apiKey, url, GetStreamString(stream), "application/octet-stream", "POST");
        }

        public virtual string SendOctetStreamPost(string apiKey, string url, Stream stream) {
            return Send(apiKey, url, GetStreamString(stream), "application/octet-stream", "POST");
        }

        public virtual async Task<string> SendJsonUpdateAsync(string apiKey, string url, string data)
        {
            return await SendAsync(apiKey, url, data, "application/json", "UPDATE");
        }

        public virtual string SendJsonUpdate(string apiKey, string url, string data) {
            return Send(apiKey, url, data, "application/json", "UPDATE");
        }

        public virtual async Task<string> SendImagePostAsync(string apiKey, string url, Stream stream)
        {
            return await SendAsync(apiKey, url, GetStreamString(stream), GetImageStreamContentType(stream), "POST");
        }

        public virtual string SendImagePost(string apiKey, string url, Stream stream) {
            return Send(apiKey, url, GetStreamString(stream), GetImageStreamContentType(stream), "POST");
        }

        public virtual async Task<string> SendAsync(string apiKey, string url, string data, string contentType, string method, string token = "", bool sendChunked = false, string host = "")
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("authorization", $"Bearer {token}");
            }

            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;

            if(sendChunked)
                request.SendChunked = true;
            if(!string.IsNullOrEmpty(host))
                request.Host = host;

            if (!string.IsNullOrEmpty(data))
            {
                byte[] reqData = Encoding.UTF8.GetBytes(data);

                request.ContentLength = (long) reqData.Length;

                Stream requestStreamAsync = await request.GetRequestStreamAsync();
                requestStreamAsync.Write(reqData, 0, reqData.Length);
                requestStreamAsync.Close();
            }
            else
            {
                request.ContentLength = 0;
            }

            string end = "";
            WebResponse responseAsync = null;
            StreamReader streamReader = null;
            Exception exHolder = null;
            try
            {
                responseAsync = await request.GetResponseAsync();
                streamReader = new StreamReader(responseAsync.GetResponseStream());
                end = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                exHolder = ex;
            }
            finally
            {
                streamReader?.Close();
                responseAsync?.Close();
                if (exHolder != null)
                    throw exHolder;
            }

            return end;
        }

        public virtual string Send(string apiKey, string url, string data, string contentType, string method, string token = "", bool sendChunked = false, string host = "") {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            if (!string.IsNullOrEmpty(token)) {
                request.Headers.Add("authorization", $"Bearer {token}");
            }

            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;

            if (sendChunked)
                request.SendChunked = true;
            if (!string.IsNullOrEmpty(host))
                request.Host = host;

            if (!string.IsNullOrEmpty(data)) {
                byte[] reqData = Encoding.UTF8.GetBytes(data);

                request.ContentLength = (long)reqData.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(reqData, 0, reqData.Length);
                requestStream.Close();
            } else {
                request.ContentLength = 0;
            }

            string end = "";
            WebResponse response = null;
            StreamReader streamReader = null;
            Exception exHolder = null;
            try {
                response = request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                end = streamReader.ReadToEnd();
            } catch (Exception ex) {
                exHolder = ex;
            } finally {
                streamReader?.Close();
                response?.Close();
                if (exHolder != null)
                    throw exHolder;
            }

            return end;
        }

        public virtual async Task<string> SendOperationPostAsync(string apiKey, string url, string data) {
            return await SendOperationPostAsync(apiKey, url, data, "application/json");
        }

        public virtual async Task<string> SendOctetOperationPostAsync(string apiKey, string url, Stream stream) {
            return await SendOperationPostAsync(apiKey, url, GetStreamString(stream), "application/octet-stream");
        }

        public virtual async Task<string> SendOperationPostAsync(string apiKey, string url, string data, string contentType)
        {

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("data");

            byte[] reqData = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.ContentType = contentType;
            request.Accept = contentType;
            request.ContentLength = (long)reqData.Length;
            request.Method = "POST";

            Stream requestStreamAsync = await request.GetRequestStreamAsync();
            requestStreamAsync.Write(reqData, 0, reqData.Length);
            requestStreamAsync.Close();

            HttpWebResponse responseAsync = (HttpWebResponse)await request.GetResponseAsync();
            var opLocation = responseAsync.GetResponseHeader("operation-location");
            responseAsync.Close();

            return opLocation;
        }

        public virtual string SendOperationPost(string apiKey, string url, string data) {
            return SendOperationPost(apiKey, url, data, "application/json");
        }

        public virtual string SendOctetOperationPost(string apiKey, string url, Stream stream) {
            return SendOperationPost(apiKey, url, GetStreamString(stream), "application/octet-stream");
        }

        public virtual string SendOperationPost(string apiKey, string url, string data, string contentType) {

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("ApiKey");
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("data");

            byte[] reqData = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.ContentType = contentType;
            request.Accept = contentType;
            request.ContentLength = (long)reqData.Length;
            request.Method = "POST";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(reqData, 0, reqData.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var opLocation = response.GetResponseHeader("operation-location");
            response.Close();

            return opLocation;
        }

        public virtual Dictionary<string, string> GetAudioHeaders(string token, AudioOutputFormatOptions outputFormat) {
            return new Dictionary<string, string>()
            {
                { "Content-Type", "application/ssml+xml" },
                { "X-Microsoft-OutputFormat", JsonConvert.SerializeObject(outputFormat) },
                { "Authorization", $"Bearer {token}" },
                { "X-Search-AppId", "07D3234E49CE426DAA29772419F436CA" },
                { "X-Search-ClientID", "1ECFAE91408841A480F00935DC390960" },
                { "User-Agent", "TTSClient" }
            };
        }

        public virtual StringContent GetAudioContent(string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType) {
            return new StringContent($"<speak version=\"1.0\" xmlns:lang=\"en-US\"><voice xmlns:lang=\"{JsonConvert.SerializeObject(locale)}\" xmlns:gender=\"{JsonConvert.SerializeObject(voiceType)}\" name=\"{voiceName}\">{text}</voice></speak>");
        }
        
        public virtual async Task<Stream> GetAudioStreamAsync(string url, string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat, string token)
        {
            HttpClientHandler handler = new HttpClientHandler() { CookieContainer = new CookieContainer(), UseProxy = false };
            HttpClient client = new HttpClient(handler);

            client.DefaultRequestHeaders.Clear();

            var Headers = GetAudioHeaders(token, outputFormat);
            
            foreach (var header in Headers) {
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url) {
                Content = GetAudioContent(text, locale, voiceName, voiceType)
            };

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);

            return await response.Content.ReadAsStreamAsync();
        }
        
        public virtual TokenResponse SendContentModeratorTokenRequest(string privateKey, string clientId)
        {
            byte[] reqData = Encoding.UTF8.GetBytes($"resource=https%3A%2F%2Fapi.contentmoderator.cognitive.microsoft.com%2Freview&client_id={clientId}&client_secret={privateKey}&grant_type=client_credentials");

            WebRequest request = WebRequest.Create("https://login.microsoftonline.com/contentmoderatorprod.onmicrosoft.com/oauth2/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = (long)reqData.Length;

            Stream requestStreamAsync = request.GetRequestStream();
            requestStreamAsync.Write(reqData, 0, reqData.Length);
            requestStreamAsync.Close();

            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            response.Close();

            TokenResponse t = new JavaScriptSerializer().Deserialize<TokenResponse>(end);

            return t;
        }

        public virtual string SendBingSpeechTokenRequest(string apiKey) {

            WebRequest request = WebRequest.Create("https://api.cognitive.microsoft.com/sts/v1.0/issueToken");
            request.Method = "POST";
            request.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
            request.ContentLength = 0;

            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            response.Close();

            return end;
        }
        
        public virtual string GetImageStreamContentType(Stream stream)
        {
            var image = Image.FromStream(stream);
            if (ImageFormat.Jpeg.Equals(image.RawFormat))
                return "image/jpeg";
            else if (ImageFormat.Png.Equals(image.RawFormat))
                return "image/png";
            else if (ImageFormat.Gif.Equals(image.RawFormat))
                return "image/gif";
            else if (ImageFormat.Bmp.Equals(image.RawFormat))
                return "image/bmp";

            throw new BadImageFormatException("The image stream provided for cognitive analysis wasn't an allowed format (jpeg, png, gif or bmp)");
        }

        public virtual string GetStreamString(Stream stream)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                sb.Append(reader.ReadToEnd());
            }

            return sb.ToString();
        }
    }
}