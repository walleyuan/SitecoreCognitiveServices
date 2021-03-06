﻿using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public interface IIntentProvider
    {
        Dictionary<string, IOleIntent> GetAllIntents(Guid appId);

        IOleIntent GetIntent(Guid appId, string intentName);

        ConversationResponse GetDefaultResponse(Guid appId);
    }
}