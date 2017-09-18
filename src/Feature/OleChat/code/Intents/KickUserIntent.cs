using System;
using System.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using Sitecore.Web.Authentication;
using System.Collections.Generic;
using Sitecore.Security.Accounts;
using System.Text.RegularExpressions;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface IKickUserIntent : IIntent { }

    public class KickUserIntent : BaseIntent, IKickUserIntent 
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "kick user";

        public override string Description => "Kick a user from the system";

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(UserKey, "What user do you want to kick? (ie: domain\\username)", IsUserValid, null)
        };

        #region Local Properties

        protected string UserKey = "Domain User";
        
        #endregion

        public KickUserIntent(
            ITextTranslatorWrapper translator,
            IAuthenticationWrapper authWrapper,
            IOleSettings settings) : base(settings) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation) {
            
            if (!AuthenticationWrapper.IsCurrentUserAdministrator())
                return CreateConversationResponse("Sorry, you can only perform this action if you're an admin");

            var userSession = (DomainAccessGuard.Session)conversation.Data[UserKey];
            var name = userSession.UserName;
            AuthenticationWrapper.Kick(userSession.SessionID);
            
            return CreateConversationResponse($"The user {name} has been kicked out.");
        }

        public virtual bool IsUserValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var userSession = (conversation.Data.ContainsKey(UserKey))
                ? (DomainAccessGuard.Session)conversation.Data[UserKey] 
                : null;

            if (userSession != null)
                return true;
            
            var username = paramValue.Replace(" ", "");
            if (string.IsNullOrEmpty(username))
                return false;

            string regex = @"^(\w[\w\s]*)([\\]{1})(\w[\w\s\.\@]*)$";
            Match m = Regex.Match(username, regex);
            if(string.IsNullOrEmpty(m.Value))
                return false;

            if (User.Exists(username))
                userSession = AuthenticationWrapper.GetDomainAccessSessions().FirstOrDefault(
                    s => string.Equals(s.UserName, username, StringComparison.OrdinalIgnoreCase));
            
            if (userSession == null)
                return false;

            conversation.Data[UserKey] = userSession;
            return true;
        }
    }
}