using System;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IDefaultIntent : IIntent { }

    public class DefaultIntent : IDefaultIntent {

        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IOleSettings Settings;

        public Guid ApplicationId => Settings.OleApplicationId;

        public string Name => "none";

        public string Description => "";

        public DefaultIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) {
            Translator = translator;
            Settings = settings;
        }
        
        public string Respond(QueryResult result, ItemContextParameters parameters) {
            return "Sorry, can you try again? I didn't quite understand you.";
        }
    }
}