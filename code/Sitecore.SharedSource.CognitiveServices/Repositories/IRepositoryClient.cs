using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.IO;

namespace Sitecore.SharedSource.CognitiveServices.Repositories
{
    public interface IRepositoryClient
    {
        Task<string> SendPostMultiPartAsync(string apiKey, string url, string data);
        Task<string> SendEncodedFormPostAsync(string apiKey, string url, string data);
        Task<string> SendOperationPostAsync(string apiKey, string url, string data);
        Task<string> SendTextPostAsync(string apiKey, string url, string data);
        Task<string> SendJsonPostAsync(string apiKey, string url, string data);
        Task<string> SendJsonDeleteAsync(string apiKey, string url, string data);
        Task<string> SendOctetStreamUpdateAsync(string apiKey, string url, Stream stream);
        Task<string> SendOctetStreamPostAsync(string apiKey, string url, Stream stream);
        Task<string> SendJsonUpdateAsync(string apiKey, string url, string data);
        Task<string> SendAsync(string apiKey, string url, string data, string contentType, string method);
        TokenResponse SendTokenRequest(string apiKey, string clientId);
        string SendTokenPost(string apiKey, string url, string token);
    }
}