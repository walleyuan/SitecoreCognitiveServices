using System;
using System.Linq;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class LoggedInUsersIntent : BaseOleIntent
    {
        protected readonly IAuthenticationWrapper AuthenticationWrapper;
        
        public override string Name => "logged in users";

        public override string Description => Translator.Text("Chat.Intents.LoggedInUsers.Name");

        public override bool RequiresConfirmation => false;

        public LoggedInUsersIntent(
            IAuthenticationWrapper authWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation) {

            var sessions = AuthenticationWrapper.GetDomainAccessSessions().OrderByDescending(s => s.LastRequest);
            var sessionCount = sessions.Count();
            var userNames = sessions.Select(a => a.UserName);
            var conjunction = (sessionCount != 1) ? Translator.Text("Chat.Intents.LoggedInUsers.PluralConjunction") : Translator.Text("Chat.Intents.LoggedInUsers.SingularConjuntion");
            var plurality = (sessionCount != 1) ? Translator.Text("Chat.Intents.LoggedInUsers.PluralLetter") : "";
            
            return ConversationResponseFactory.Create($"{string.Format(Translator.Text("Chat.Intents.LoggedInUsers.Response"), conjunction, sessionCount, plurality)} <br/><ul><li>{string.Join("</li><li>", userNames)}</li></ul>");
        }
    }
}