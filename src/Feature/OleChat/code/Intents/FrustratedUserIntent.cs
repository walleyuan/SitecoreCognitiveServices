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
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class FrustratedUserIntent : BaseOleIntent
    {
        public override string Name => "frustrated user";

        public override string Description => "";

        public override bool RequiresConfirmation => false;

        public FrustratedUserIntent(
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings)
        {
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            List<string> responses = new List<string>()
            {
                Translator.Text("Chat.Intents.FrustratedUser.1"),
                Translator.Text("Chat.Intents.FrustratedUser.2"),
                Translator.Text("Chat.Intents.FrustratedUser.3"),
                Translator.Text("Chat.Intents.FrustratedUser.4"),
                Translator.Text("Chat.Intents.FrustratedUser.5"),
                Translator.Text("Chat.Intents.FrustratedUser.6")
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}