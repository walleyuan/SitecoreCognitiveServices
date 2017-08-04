using System;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {
    public interface IGreetIntent : IIntent { }

    public class GreetIntent : IGreetIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IOleSettings Settings;

        public Guid ApplicationId => Settings.OleApplicationId;

        public string Name => "greet";

        public string Description => "Greet a user";

        public GreetIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) {
            Translator = translator;
            Settings = settings;
        }

        public string Respond(LuisResult result, ItemContextParameters parameters)
        {
            string fullName = Sitecore.Context.User.Profile.FullName;
            
            return $"Hi {fullName}, how can I help you?";
        }
    }
}