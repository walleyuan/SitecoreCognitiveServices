﻿using System;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.Web.Authentication;
using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Security.Accounts;
using System.Text.RegularExpressions;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IKickUserIntent : IIntent { }

    public class KickUserIntent : BaseIntent, IKickUserIntent 
    {
        protected readonly ITextTranslatorWrapper Translator;
        
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
            IOleSettings settings) : base(settings) {
            Translator = translator;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation) {
            
            if (!Sitecore.Context.User.IsAdministrator)
                return CreateConversationResponse("Sorry, you can only perform this action if you're an admin");

            var userSession = (DomainAccessGuard.Session)conversation.Data[UserKey];
            var name = userSession.UserName;
            DomainAccessGuard.Kick(userSession.SessionID);
            
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
                userSession = DomainAccessGuard.Sessions.FirstOrDefault(
                    s => string.Equals(s.UserName, username, StringComparison.OrdinalIgnoreCase));
            
            if (userSession == null)
                return false;

            conversation.Data[UserKey] = userSession;
            return true;
        }
    }
}