using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public interface IFrustratedUserIntent : IOleIntent { }

    public class FrustratedUserIntent : BaseOleIntent, IFrustratedUserIntent
    {
        protected readonly ITextTranslatorWrapper Translator;

        public override string Name => "frustrated user";

        public override string Description => "";

        public FrustratedUserIntent(
            ITextTranslatorWrapper translator,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings)
        {
            Translator = translator;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            List<string> responses = new List<string>()
            {
                "I can sense you're getting frustrated. Please have patience with me. I'm still learning.",
                "Let's take a break and try to relax a little.",
                "Before you're fed up with me, let's just slow down and try again.",
                "I know I'm not perfect but I'm not that bad am I?",
                "I'm trying to help but it looks like I'm making you mad.",
                "That type of language is really uncalled for.",
                "Do you really want to talk to me like that.",
                "I don't like you're disrespectful tone.",
                "How rude!",
                "I'm here to help so let's try to stay calm"
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}