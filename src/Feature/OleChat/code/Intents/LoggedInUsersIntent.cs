using System;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface ILoggedInUsersIntent : IIntent { }

    public class LoggedInUsersIntent : BaseIntent, ILoggedInUsersIntent 
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;
        
        public override string Name => "logged in users";

        public override string Description => "List the logged in users";

        public LoggedInUsersIntent(
            ITextTranslatorWrapper translator,
            IAuthenticationWrapper authWrapper,
            IOleSettings settings) : base(settings) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation) {

            var sessions = AuthenticationWrapper.GetDomainAccessSessions().OrderByDescending(s => s.LastRequest);
            var sessionCount = sessions.Count();
            var userNames = sessions.Select(a => a.UserName);
            var conjunction = (sessionCount != 1) ? "are" : "is";
            var plurality = (sessionCount != 1) ? "s" : "";
            
            return CreateConversationResponse($"There {conjunction} {sessionCount} user{plurality}. <br/><ul><li>{string.Join("</li><li>", userNames)}</li></ul>");
        }
    }
}