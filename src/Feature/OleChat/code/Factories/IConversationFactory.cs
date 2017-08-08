using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Factories
{
    public interface IConversationFactory
    {
        IConversation Create(LuisResult result, IIntent intent);
    }
}