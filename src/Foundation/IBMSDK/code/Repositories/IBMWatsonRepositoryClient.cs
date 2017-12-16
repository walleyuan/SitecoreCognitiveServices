using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Repositories
{
    public class IBMWatsonRepositoryClient : IIBMWatsonRepositoryClient
    {
        public virtual async Task<string> SendGetAsync(string apiUsername, string apiPassword, string url) {
            return await SendAsync(apiUsername, apiPassword, url, null, "application/json", "GET");
        }

        public virtual string SendGet(string apiUsername, string apiPassword, string url) {
            return Send(apiUsername, apiPassword, url, null, "application/json", "GET");
        }

        public virtual async Task<string> SendPostMultiPartAsync(string apiUsername, string apiPassword, string url, string data)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "multipart/form-data", "POST");
        }

        public virtual string SendPostMultiPart(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "multipart/form-data", "POST");
        }

        public virtual async Task<string> SendEncodedFormPostAsync(string apiUsername, string apiPassword, string url, string data)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "application/x-www-form-urlencoded", "POST");
        }

        public virtual string SendEncodedFormPost(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "application/x-www-form-urlencoded", "POST");
        }

        public virtual async Task<string> SendTextPostAsync(string apiUsername, string apiPassword, string url, string data)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "text/plain", "POST");
        }

        public virtual string SendTextPost(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "text/plain", "POST");
        }

        public virtual async Task<string> SendJsonPostAsync(string apiUsername, string apiPassword, string url, string data)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "POST");
        }

        public virtual string SendJsonPost(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "POST");
        }

        public virtual async Task<string> SendJsonPutAsync(string apiUsername, string apiPassword, string url, string data)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "PUT");
        }

        public virtual string SendJsonPut(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "PUT");
        }

        public virtual async Task<string> SendJsonPatchAsync(string apiUsername, string apiPassword, string url, string data) {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "PATCH");
        }

        public virtual string SendJsonPatch(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "PATCH");
        }

        public virtual async Task<string> SendJsonDeleteAsync(string apiUsername, string apiPassword, string url)
        {
            return await SendAsync(apiUsername, apiPassword, url, null, "application/json", "DELETE");
        }

        public virtual string SendJsonDelete(string apiUsername, string apiPassword, string url) {
            return Send(apiUsername, apiPassword, url, null, "application/json", "DELETE");
        }

        public virtual async Task<string> SendOctetStreamUpdateAsync(string apiUsername, string apiPassword, string url, Stream stream)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(stream), "application/octet-stream", "UPDATE");
        }

        public virtual string SendOctetStreamUpdate(string apiUsername, string apiPassword, string url, Stream stream) {
            return Send(apiUsername, apiPassword, url, GetByteArray(stream), "application/octet-stream", "UPDATE");
        }

        public virtual async Task<string> SendOctetStreamPostAsync(string apiUsername, string apiPassword, string url, Stream stream)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(stream), "application/octet-stream", "POST");
        }

        public virtual string SendOctetStreamPost(string apiUsername, string apiPassword, string url, Stream stream) {
            return Send(apiUsername, apiPassword, url, GetByteArray(stream), "application/octet-stream", "POST");
        }

        public virtual async Task<string> SendJsonUpdateAsync(string apiUsername, string apiPassword, string url, string data)
        {
            return await SendAsync(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "UPDATE");
        }

        public virtual string SendJsonUpdate(string apiUsername, string apiPassword, string url, string data) {
            return Send(apiUsername, apiPassword, url, GetByteArray(data), "application/json", "UPDATE");
        }
        
        public virtual async Task<string> SendAsync(string apiUsername, string apiPassword, string url, byte[] data, string contentType, string method)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiUsername))
                throw new ArgumentException("ApiKey");
            if (string.IsNullOrWhiteSpace(apiPassword))
                throw new ArgumentException("ApiKey");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential(){ UserName = apiUsername, Password = apiPassword };
            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;
            
            if (data != null)
            {
                request.ContentLength = data.Length;
                Stream requestStreamAsync = await request.GetRequestStreamAsync();
                requestStreamAsync.Write(data, 0, data.Length);
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

        public virtual string Send(string apiUsername, string apiPassword, string url, byte[] data, string contentType, string method) {

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("url");
            if (string.IsNullOrWhiteSpace(apiUsername))
                throw new ArgumentException("ApiKey");
            if (string.IsNullOrWhiteSpace(apiPassword))
                throw new ArgumentException("ApiKey");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential() { UserName = apiUsername, Password = apiPassword };
            request.ContentType = contentType;
            request.Accept = contentType;
            request.Method = method;
            
            if (data != null)
            {
                request.ContentLength = data.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
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
        
        public virtual byte[] GetByteArray(Stream stream)
        {
            if (stream is MemoryStream)
                return ((MemoryStream)stream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public virtual byte[] GetByteArray(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
    }
}