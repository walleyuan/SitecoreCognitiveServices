using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {
    public interface IGreetIntent : IIntent { }

    public class GreetIntent : BaseIntent, IGreetIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "greet";

        public override string Description => "Greet a user";

        public GreetIntent(
            ITextTranslatorWrapper translator,
            IAuthenticationWrapper authWrapper,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(settings, responseFactory) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            string fullName = AuthenticationWrapper.GetCurrentUser().Profile.FullName;

            List<string> responses = new List<string>()
            {
                $"Hi {fullName}, how can I help you?",
                "What's up?",
                "What can I do for you?",
                "Hey.",
                "Hi.",
                "Can I help you with something?"
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}