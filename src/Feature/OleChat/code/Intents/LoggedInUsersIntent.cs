using System;
using System.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

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
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(settings, responseFactory) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation) {

            var sessions = AuthenticationWrapper.GetDomainAccessSessions().OrderByDescending(s => s.LastRequest);
            var sessionCount = sessions.Count();
            var userNames = sessions.Select(a => a.UserName);
            var conjunction = (sessionCount != 1) ? "are" : "is";
            var plurality = (sessionCount != 1) ? "s" : "";
            
            return ConversationResponseFactory.Create($"There {conjunction} {sessionCount} user{plurality}. <br/><ul><li>{string.Join("</li><li>", userNames)}</li></ul>");
        }
    }
}