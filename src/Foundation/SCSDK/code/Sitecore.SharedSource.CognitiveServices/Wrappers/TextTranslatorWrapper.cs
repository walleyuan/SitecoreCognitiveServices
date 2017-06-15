
namespace Sitecore.SharedSource.CognitiveServices.Wrappers
{
    public class TextTranslatorWrapper : ITextTranslatorWrapper {
        public string Translate(string key) {        
            return Sitecore.Globalization.Translate.Text(key) ?? string.Empty;
        }
    }
}