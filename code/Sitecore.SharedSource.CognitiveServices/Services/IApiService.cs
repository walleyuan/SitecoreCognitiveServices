using System.Drawing;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public interface IApiService
    {
        Size CalculateDimensions(Size oldSize, int maxSize);
    }
}
