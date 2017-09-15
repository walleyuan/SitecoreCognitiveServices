using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models;
using System.IO;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Common;

namespace Microsoft.SharedSource.CognitiveServices.Repositories
{
    public interface IRepositoryClient
    {
        Task<string> SendGetAsync(string apiKey, string url);
        string SendGet(string apiKey, string url);
        Task<string> SendPostMultiPartAsync(string apiKey, string url, string data);
        string SendPostMultiPart(string apiKey, string url, string data);
        Task<string> SendEncodedFormPostAsync(string apiKey, string url, string data);
        string SendEncodedFormPost(string apiKey, string url, string data);
        Task<string> SendTextPostAsync(string apiKey, string url, string data);
        string SendTextPost(string apiKey, string url, string data);
        Task<string> SendJsonPostAsync(string apiKey, string url, string data);
        string SendJsonPost(string apiKey, string url, string data);
        Task<string> SendJsonPutAsync(string apiKey, string url, string data);
        string SendJsonPut(string apiKey, string url, string data);
        Task<string> SendJsonPatchAsync(string apiKey, string url, string data);
        string SendJsonPatch(string apiKey, string url, string data);
        Task<string> SendJsonDeleteAsync(string apiKey, string url);
        string SendJsonDelete(string apiKey, string url);
        Task<string> SendOctetStreamUpdateAsync(string apiKey, string url, Stream stream);
        string SendOctetStreamUpdate(string apiKey, string url, Stream stream);
        Task<string> SendOctetStreamPostAsync(string apiKey, string url, Stream stream);
        string SendOctetStreamPost(string apiKey, string url, Stream stream);
        Task<string> SendJsonUpdateAsync(string apiKey, string url, string data);
        string SendJsonUpdate(string apiKey, string url, string data);
        Task<string> SendImagePostAsync(string apiKey, string url, Stream stream);
        string SendImagePost(string apiKey, string url, Stream stream);
        Task<string> SendAsync(string apiKey, string url, byte[] data, string contentType, string method, string token = "", bool sendChunked = false, string host = "");
        string Send(string apiKey, string url, byte[] data, string contentType, string method, string token = "", bool sendChunked = false, string host = "");
        Task<string> SendOperationPostAsync(string apiKey, string url, string data);
        Task<string> SendOctetOperationPostAsync(string apiKey, string url, Stream stream);
        Task<string> SendOperationPostAsync(string apiKey, string url, byte[] data, string contentType);
        string SendOperationPost(string apiKey, string url, string data);
        string SendOctetOperationPost(string apiKey, string url, Stream stream);
        string SendOperationPost(string apiKey, string url, byte[] data, string contentType);
        Task<Stream> GetAudioStreamAsync(string url, string text, BingSpeechLocaleOptions locale, string voiceName, GenderOptions voiceType, AudioOutputFormatOptions outputFormat, string token);
        TokenResponse SendContentModeratorTokenRequest(string apiKey, string clientId);
        string SendBingSpeechTokenRequest(string apiKey);
        string GetImageStreamContentType(Stream stream);
        byte[] GetByteArray(Stream stream);
        byte[] GetByteArray(string value);
    }
}