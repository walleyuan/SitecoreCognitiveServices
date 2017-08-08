using System;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IDefaultIntent : IIntent { }

    public class DefaultIntent : BaseIntent, IDefaultIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "none";

        public override string Description => "";

        public DefaultIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings) {
            Translator = translator;
        }
        
        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            return "Sorry, can you try again? I didn't quite understand you.";
        }
    }
}