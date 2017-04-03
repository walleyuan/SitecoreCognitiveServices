using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.Web.Authentication;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public class KickUserIntent : IIntent {
        public string Name => "kick user";

        public string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters) {

            //check if you're the admin user
            if (!Sitecore.Context.User.IsAdministrator)
                return "Sorry, you can only perform this action if you're an admin";
            
            var user = result?.Entities?.FirstOrDefault(x => x.Type.Equals("Domain User"))?.Entity;
            if (string.IsNullOrEmpty(user))
                return "Sorry, that's not a valid user name.";

            var username = user.Replace(" ", "");
            var session = DomainAccessGuard.Sessions.FirstOrDefault(s => s.UserName.Equals(username));
            if (session == null)
                return "Sorry, I couldn't find that user.";

            DomainAccessGuard.Kick(session.SessionID);
            
            return $"The user {username} has been kicked out.";
        }
    }
}