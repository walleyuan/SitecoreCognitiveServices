using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IVisionService
    {
        Description GetDescription(MediaItem mediaItem);
        void SetImageDescription(MediaItem mediaItem, string altDescription);
    }
}