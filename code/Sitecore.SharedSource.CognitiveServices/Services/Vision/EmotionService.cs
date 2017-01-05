using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System.IO;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class EmotionService : IEmotionService
    {
        public IEmotionRepository EmotionRepository;

        public EmotionService(IEmotionRepository emotionRepository)
        {
            EmotionRepository = emotionRepository;
        }

        
    }
}