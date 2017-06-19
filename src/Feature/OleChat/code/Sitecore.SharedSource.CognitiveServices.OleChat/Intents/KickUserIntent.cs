using System;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.Web.Authentication;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IKickUserIntent : IIntent { }

    public class KickUserIntent : IKickUserIntent 
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IOleSettings Settings;

        public Guid ApplicationId => Settings.OleApplicationId;

        public string Name => "kick user";

        public string Description => "Kick a user from the system";

        public KickUserIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) {
            Translator = translator;
            Settings = settings;
        }

        public string Respond(LuisResult result, ItemContextParameters parameters) {

            if (!Sitecore.Context.User.IsAdministrator)
                return "Sorry, you can only perform this action if you're an admin";
            
            var user = result?.Entities?.FirstOrDefault(x => x.Type.Equals("Domain User"))?.Entity;
            if (string.IsNullOrEmpty(user))
                return "Sorry, that's not a valid user name.";

            var username = user.Replace(" ", "");
            var session = DomainAccessGuard.Sessions.FirstOrDefault(s => string.Equals(s.UserName, username, StringComparison.OrdinalIgnoreCase));
            if (session == null)
                return "Sorry, I couldn't find that user.";

            DomainAccessGuard.Kick(session.SessionID);
            
            return $"The user {username} has been kicked out.";
        }
    }
}