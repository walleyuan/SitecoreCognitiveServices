
namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class WebUtilWrapper : IWebUtilWrapper
    {
        public virtual string GetQueryString(string key, string defaultValue = "")
        {
            string value = Sitecore.Web.WebUtil.GetQueryString(key, defaultValue);
            return (string.IsNullOrEmpty(value))
                ? defaultValue
                : value;
        }
    }
}