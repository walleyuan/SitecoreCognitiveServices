using System.Threading.Tasks;
using System.IO;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Repositories
{
    public interface IIBMWatsonRepositoryClient
    {
        Task<string> SendGetAsync(string apiUsername, string apiPassword, string url);
        string SendGet(string apiUsername, string apiPassword, string url);
        Task<string> SendPostMultiPartAsync(string apiUsername, string apiPassword, string url, string data);
        string SendPostMultiPart(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendEncodedFormPostAsync(string apiUsername, string apiPassword, string url, string data);
        string SendEncodedFormPost(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendTextPostAsync(string apiUsername, string apiPassword, string url, string data);
        string SendTextPost(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendJsonPostAsync(string apiUsername, string apiPassword, string url, string data);
        string SendJsonPost(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendJsonPutAsync(string apiUsername, string apiPassword, string url, string data);
        string SendJsonPut(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendJsonPatchAsync(string apiUsername, string apiPassword, string url, string data);
        string SendJsonPatch(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendJsonDeleteAsync(string apiUsername, string apiPassword, string url);
        string SendJsonDelete(string apiUsername, string apiPassword, string url);
        Task<string> SendOctetStreamUpdateAsync(string apiUsername, string apiPassword, string url, Stream stream);
        string SendOctetStreamUpdate(string apiUsername, string apiPassword, string url, Stream stream);
        Task<string> SendOctetStreamPostAsync(string apiUsername, string apiPassword, string url, Stream stream);
        string SendOctetStreamPost(string apiUsername, string apiPassword, string url, Stream stream);
        Task<string> SendJsonUpdateAsync(string apiUsername, string apiPassword, string url, string data);
        string SendJsonUpdate(string apiUsername, string apiPassword, string url, string data);
        Task<string> SendAsync(string apiUsername, string apiPassword, string url, byte[] data, string contentType, string method);
        string Send(string apiUsername, string apiPassword, string url, byte[] data, string contentType, string method);
        byte[] GetByteArray(Stream stream);
        byte[] GetByteArray(string value);
    }
}