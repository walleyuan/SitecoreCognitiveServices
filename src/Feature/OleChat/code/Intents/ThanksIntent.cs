using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class ThanksIntent : BaseOleIntent
    {
        public override string Name => "thanks";

        public override string Description => "";

        public override bool RequiresConfirmation => false;

        public ThanksIntent(
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings)
        {
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            List<string> responses = new List<string>()
            {
                Translator.Text("Chat.Intents.Thanks.1"),
                Translator.Text("Chat.Intents.Thanks.2"),
                Translator.Text("Chat.Intents.Thanks.3"),
                Translator.Text("Chat.Intents.Thanks.4"),
                Translator.Text("Chat.Intents.Thanks.5"),
                Translator.Text("Chat.Intents.Thanks.6"),
                Translator.Text("Chat.Intents.Thanks.7")
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}