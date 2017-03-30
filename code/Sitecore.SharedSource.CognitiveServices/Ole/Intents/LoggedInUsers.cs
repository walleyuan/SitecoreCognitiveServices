using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.Web.Authentication;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public class LoggedInUsersIntent : IIntent {
        public string Name => "logged in users";

        public string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters) {

            var sessions = DomainAccessGuard.Sessions.OrderByDescending(s => s.LastRequest);
            var sessionCount = sessions.Count();
            var userNames = sessions.Select(a => a.UserName);
            var conjunction = (sessionCount != 1) ? "are" : "is";
            var plurality = (sessionCount != 1) ? "s" : "";

            return $"There {conjunction} {sessionCount} user{plurality}. <br/><ul><li>{string.Join("</li><li>", userNames)}</li></ul>";
        }
    }
}