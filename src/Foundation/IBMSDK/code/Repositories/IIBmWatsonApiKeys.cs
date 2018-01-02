
namespace SitecoreCognitiveServices.Foundation.IBMSDK
{
    public interface IIBMWatsonApiKeys
    {
        string NaturalLanguageClassifier { get; }
        string NaturalLanguageClassifierEndpoint { get; }
        string NaturalLanguageClassifierUsername { get; }
        string NaturalLanguageClassifierPassword { get; }
        int NaturalLanguageClassifierRetryInSeconds { get; }
        string GetStringValue(string fieldName);
        int GetIntValue(string fieldName);
    }
}
