using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.Models.Ole;
using Sitecore.Web.Authentication;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {

    public interface ILoggedInUsersIntent : IIntent { }

    public class LoggedInUsersIntent : ILoggedInUsersIntent 
    {
        protected readonly ITextTranslator Translator;

        public string Name => "logged in users";

        public LoggedInUsersIntent(ITextTranslator translator) {
            Translator = translator;
        }

        public string Respond(QueryResult result, ItemContextParameters parameters) {

            var sessions = DomainAccessGuard.Sessions.OrderByDescending(s => s.LastRequest);
            var sessionCount = sessions.Count();
            var userNames = sessions.Select(a => a.UserName);
            var conjunction = (sessionCount != 1) ? "are" : "is";
            var plurality = (sessionCount != 1) ? "s" : "";

            return $"There {conjunction} {sessionCount} user{plurality}. <br/><ul><li>{string.Join("</li><li>", userNames)}</li></ul>";
        }
    }
}