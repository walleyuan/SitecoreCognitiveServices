﻿
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using System.IO;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Vision
{
    public interface IEmotionService
    {
        Emotion[] Recognize(Stream stream);
        Emotion[] Recognize(string imageUrl);
    }
}