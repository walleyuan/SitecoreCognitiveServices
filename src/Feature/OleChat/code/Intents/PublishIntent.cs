using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class PublishIntent : BaseOleIntent
    {
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IPublishWrapper PublishWrapper;
        
        public override string Name => "publish";

        public override string Description => Translator.Text("Chat.Intents.Publish.Name");

        public override bool RequiresConfirmation => true;

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(ItemKey, Translator.Text("Chat.Intents.Publish.ItemParameterRequest"), GetValidPath, null),
            new ConversationParameter(DBKey, Translator.Text("Chat.Intents.Publish.DBParameterRequest"), GetValidDb, DbOptions),
            new ConversationParameter(LangKey, Translator.Text("Chat.Intents.Publish.LangParameterRequest"), GetValidLanguage, LanguageOptions),
            new ConversationParameter(RecursionKey, Translator.Text("Chat.Intents.Publish.RecursionParameterRequest"), GetValidRecursion, RecursionOptions)
        };

        #region Local Properties

        protected string DBKey = "Database Name";
        protected string ItemKey = "Item Path";
        protected string LangKey = "Language";
        protected string RecursionKey = "Descendants";
        
        #endregion
        
        public PublishIntent(
            IOleSettings settings,
            ISitecoreDataWrapper dataWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IPublishWrapper publishWrapper) : base(optionSetFactory, responseFactory, settings)
        {
            DataWrapper = dataWrapper;
            PublishWrapper = publishWrapper;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var toDb = (Database) conversation.Data[DBKey];
            var rootItem = (Item) conversation.Data[ItemKey];
            var langItem = (Language) conversation.Data[LangKey];
            var recursion = (string) conversation.Data[RecursionKey];
            PublishWrapper.PublishItem(rootItem, new[] { toDb }, new[] { langItem }, recursion.Equals("y"), false);

            var recursionMessage = recursion.Equals("y") 
                ? Translator.Text("Chat.Intents.Publish.ResponseRecursion") 
                : string.Empty;
            
            return ConversationResponseFactory.Create(string.Format(Translator.Text("Chat.Intents.Publish.Response"), rootItem.DisplayName, toDb.Name, rootItem.Language.Name.ToUpper(), recursionMessage));
        }

        #region DB

        public virtual Database GetValidDb(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            try { 
                return DataWrapper.GetDatabase(paramValue);
            }
            catch { }

            return null;
        }

        public virtual IntentOptionSet DbOptions(ItemContextParameters parameters)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : Settings.MasterDatabase;
            var publishingTargets = PublishWrapper.GetPublishingTargets(dbName);
            
            return IntentOptionSetFactory.Create(IntentOptionType.Link, publishingTargets.ToList());
        }

        #endregion

        #region Path

        public virtual Item GetValidPath(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var fromDb = DataWrapper.GetDatabase(parameters.Database);
            return fromDb.GetItem(paramValue);
        }

        #endregion

        #region Recursion

        public virtual string GetValidRecursion(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return Translator.Text("Chat.Intents.Publish.Yes").Equals(paramValue) ? "y" : "n";
        }

        public virtual IntentOptionSet RecursionOptions(ItemContextParameters parameters)
        {
            var options = new List<string>{ Translator.Text("Chat.Intents.Publish.Yes"), Translator.Text("Chat.Intents.Publish.No") };

            return IntentOptionSetFactory.Create(IntentOptionType.Link, options);
        }

        #endregion

        #region Language

        public virtual Language GetValidLanguage(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : Settings.MasterDatabase;
            var db = DataWrapper.GetDatabase(dbName);
            var langs = DataWrapper.GetLanguages(db).Where(a => a.Name.Equals(paramValue)).ToList();

            return langs.Any() ? langs.First() : null;
        }

        public virtual IntentOptionSet LanguageOptions(ItemContextParameters parameters)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : Settings.MasterDatabase;
            var db = DataWrapper.GetDatabase(dbName);
             
            var options = DataWrapper.GetLanguages(db).Select(a => a.Name).ToList();

            return IntentOptionSetFactory.Create(IntentOptionType.Link, options);
        }

        #endregion
    }
}