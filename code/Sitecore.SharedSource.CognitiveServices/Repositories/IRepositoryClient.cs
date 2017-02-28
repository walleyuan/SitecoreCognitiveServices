using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Repositories
{
    public interface IRepositoryClient
    {
        Task<string> SendPostMultiPartAsync(string apiKey, string url, string data);
        Task<string> SendEncodedFormPostAsync(string apiKey, string url, string data);
        Task<string> SendOperationPostAsync(string apiKey, string url, string data);
        Task<string> SendTextPostAsync(string apiKey, string url, string data);
        Task<string> SendJsonPostAsync(string apiKey, string url, string data);
        TokenResponse SendTokenRequest(string apiKey, string clientId);
        string SendTokenPost(string apiKey, string url, string token);
    }
}