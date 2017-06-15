
using System.IO;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IEmotionService
    {
        Emotion[] Recognize(Stream stream);
        Emotion[] Recognize(string imageUrl);
    }
}