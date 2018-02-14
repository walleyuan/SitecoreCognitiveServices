using System;
using System.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using Sitecore.Web.Authentication;
using System.Collections.Generic;
using Sitecore.Security.Accounts;
using System.Text.RegularExpressions;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class KickUserIntent : BaseOleIntent
    {
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "kick user";

        public override string Description => Translator.Text("Chat.Intents.KickUser.Name");

        public override bool RequiresConfirmation => true;

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(UserKey, Translator.Text("Chat.Intents.KickUser.UserParameterRequest"), GetValidUser, null)
        };

        #region Local Properties

        protected string UserKey = "Domain User";
        
        #endregion

        public KickUserIntent(
            IAuthenticationWrapper authWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation) {
            
            if (!AuthenticationWrapper.IsCurrentUserAdministrator())
                return ConversationResponseFactory.Create(Translator.Text("Chat.Intents.KickUser.MustBeAdminMessage"));

            var userSession = (DomainAccessGuard.Session)conversation.Data[UserKey];
            var name = userSession.UserName;
            AuthenticationWrapper.Kick(userSession.SessionID);
            
            return ConversationResponseFactory.Create(string.Format(Translator.Text("Chat.Intents.KickUser.Response"), name));
        }

        public virtual DomainAccessGuard.Session GetValidUser(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var username = paramValue.Replace(" ", "");
            if (string.IsNullOrEmpty(username))
                return null;

            string regex = @"^(\w[\w\s]*)([\\]{1})(\w[\w\s\.\@]*)$";
            Match m = Regex.Match(username, regex);
            if(string.IsNullOrEmpty(m.Value))
                return null;

            DomainAccessGuard.Session userSession = null;
            if (User.Exists(username))
                userSession = AuthenticationWrapper.GetDomainAccessSessions().FirstOrDefault(
                    s => string.Equals(s.UserName, username, StringComparison.OrdinalIgnoreCase));

            return userSession;
        }
    }
}