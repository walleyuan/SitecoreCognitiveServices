using System;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface ILogoutIntent : IIntent { }

    public class LogoutIntent : BaseIntent, ILogoutIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "logout";

        public override string Description => "Logout the current user from Sitecore";
        
        public LogoutIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings) {
            Translator = translator;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation) {

            Sitecore.Security.Authentication.AuthenticationManager.Logout();
            
            return CreateConversationResponse($"You have been logged out.");
        }
    }
}