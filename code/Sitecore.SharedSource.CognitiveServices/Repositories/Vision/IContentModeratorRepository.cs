
namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public interface IContentModeratorRepository
    {
        string Evaluate(string imageUrl);
    }
}