
namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class WebUtilWrapper : IWebUtilWrapper
    {
        public string GetQueryString(string key, string defaultValue = "")
        {
            return Sitecore.Web.WebUtil.GetQueryString(key, defaultValue);
        }
    }
}