
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
using System.IO;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IEmotionService
    {
        Emotion[] Recognize(Stream stream);
        Emotion[] Recognize(string imageUrl);
    }
}