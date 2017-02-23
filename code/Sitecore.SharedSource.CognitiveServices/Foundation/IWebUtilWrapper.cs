
namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public interface IWebUtilWrapper
    {
        string GetQueryString(string key, string defaultValue = "");
        string UrlEncode(string value);
    }
}