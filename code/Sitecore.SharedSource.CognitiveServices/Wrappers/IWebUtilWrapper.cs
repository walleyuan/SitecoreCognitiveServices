
namespace Sitecore.SharedSource.CognitiveServices.Wrappers
{
    public interface IWebUtilWrapper
    {
        string GetQueryString(string key, string defaultValue = "");
        string UrlEncode(string value);
    }
}