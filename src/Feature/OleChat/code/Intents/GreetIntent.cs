using System;
using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {
    public interface IGreetIntent : IIntent { }

    public class GreetIntent : BaseIntent, IGreetIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "greet";

        public override string Description => "Greet a user";

        public GreetIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings) {
            Translator = translator;
        }

        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            string fullName = Sitecore.Context.User.Profile.FullName;

            List<string> responses = new List<string>()
            {
                $"Hi {fullName}, how can I help you?",
                "What's up?",
                "What can I do for you?",
                "Hey.",
                "Hi.",
                "Can I help you with something?"
            };

            return responses[new Random().Next(0, responses.Count)];
        }
    }
}