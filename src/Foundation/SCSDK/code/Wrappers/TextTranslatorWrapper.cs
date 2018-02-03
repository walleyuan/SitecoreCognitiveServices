
namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface ITextTranslatorWrapper
    {
        string Text(string key);
        string TextByDomain(string key, string domain);
    }

    public class TextTranslatorWrapper : ITextTranslatorWrapper
    {
        public string Text(string key)
        {
            return Sitecore.Globalization.Translate.Text(key) ?? string.Empty;
        }
        public string TextByDomain(string key, string domain)
        {        
            return Sitecore.Globalization.Translate.TextByDomain(key, domain) ?? string.Empty;
        }
    }
}