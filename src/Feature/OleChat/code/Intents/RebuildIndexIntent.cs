using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using Sitecore.Data;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using Sitecore.ContentSearch;
using Sitecore.Jobs;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.ContentSearch.Maintenance;
using SitecoreCognitiveServices.Feature.OleChat.Factories;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface IRebuildIndexIntent : IIntent { }

    public class RebuildIndexIntent : BaseIntent, IRebuildIndexIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IPublishWrapper PublishWrapper;
        
        public override string Name => "rebuild index";

        public override string Description => "Rebuild an Index";

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(IndexKey, "What index do you want to rebuild?", IsIndexValid, IndexOptions)
        };

        #region Local Properties

        protected string IndexKey = "Index Name";
        
        #endregion
        
        public RebuildIndexIntent(
            ITextTranslatorWrapper translator,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(settings, responseFactory)
        {
            Translator = translator;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            //var toDb = (Database) conversation.Data[DBKey];
            //PublishWrapper.PublishItem(rootItem, new[] { toDb }, new[] { rootItem.Language }, recursion, false);


            ////////////////////////
            //var index = (ISearchIndex)conversation.Data[IndexKey];
            
            //Job job2 = IndexCustodian.FullRebuild(index, true);
            //while (job2 != null && !job2.IsDone)
            //{
            //    string str = string.Format("{0}: {1}. ", (object)this.Translate.TextByLanguage("Status", language), (object)this.Translate.TextByLanguage(job2.Status.State.ToString(), language));
            //    if (job2.Status.State == JobState.Running)
            //        str += string.Format("{0}: {1}.", (object)this.Translate.TextByLanguage("Processed", language), (object)job2.Status.Processed);
            //    job1.Status.Messages.Add(str);
            //    Thread.Sleep(500);
            //}
            //if (job2 == null || !job2.Status.Failed)
            //    return;

            ////////////////////////

            /// rebuild all ///
            /// 

        //    Log.Audit("Rebuild all indexes", (object)this);
        //    List<Job> list = IndexCustodian.RebuildAll(new IndexGroup[1]
        //    {
        //IndexGroup.Experience
        //    }).ToList<Job>();
        //    while (true)
        //    {
        //        List<Job> source = list;
        //        Func<Job, bool> func = (Func<Job, bool>)(j => !j.IsDone);
        //        Func<Job, bool> predicate;
        //        if (source.Any<Job>(predicate))
        //            Thread.Sleep(500);
        //        else
        //            break;
        //    }
        //    int num = list.Count<Job>((Func<Job, bool>)(j => j.Status.Failed));
        //    if (num <= 0)
        //        return;


            //////////////////

            return ConversationResponseFactory.Create($"message");
        }

        public virtual bool IsIndexValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var index = (conversation.Data.ContainsKey(IndexKey))
                ? (ISearchIndex)conversation.Data[IndexKey]
                : null;

            if (index != null)
                return true;

            if (string.IsNullOrEmpty(paramValue))
                return false;

            index = ContentSearchManager.GetIndex(paramValue);
            
            if (index == null)
                return false;

            conversation.Data[IndexKey] = index;
            return true;
        }

        public virtual Dictionary<string, string> IndexOptions()
        {
            return DataWrapper.GetDatabases().ToDictionary(a => a.Name, a => a.Name);
        }
    }
}