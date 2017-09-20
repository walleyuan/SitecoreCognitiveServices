﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Intents;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Language;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class ConversationService : IConversationService
    {
        protected readonly IIntentProvider IntentProvider;
        protected readonly ILuisService LuisService;
        protected readonly IOleSettings OleSettings;
        protected readonly IConversationHistory ConversationHistory;
        protected readonly IConversationFactory ConversationFactory;
        protected readonly IConversationResponseFactory ConversationResponseFactory;
        
        protected readonly Guid AppId;
        protected string ReqParam = "RequestParam";

        public ConversationService(
            IIntentProvider intentProvider,
            ILuisService luisService,
            IOleSettings oleSettings,
            IConversationHistory convoHistory,
            IConversationFactory convoFactory,
            IConversationResponseFactory responseFactory)
        {
            IntentProvider = intentProvider;
            LuisService = luisService;
            OleSettings = oleSettings;
            ConversationHistory = convoHistory;
            ConversationFactory = convoFactory;
            ConversationResponseFactory = responseFactory;

            AppId = OleSettings.OleApplicationId;
        }

        public ConversationResponse HandleMessage(Activity activity, ItemContextParameters parameters)
        {
            // determine which intent user wants and context
            var result = LuisService.Query(AppId, activity.Text);
            var intent = IntentProvider.GetIntent(AppId, result.TopScoringIntent.Intent);

            // respond with fallback / default
            if(intent == null)
                return IntentProvider.GetDefaultResponse(AppId);

            IConversation conversation = (ConversationHistory.Conversations.Any())
                ? ConversationHistory.Conversations.Last()
                : null;

            var requestedQuit = intent.Name.Equals("quit");
            var inConversation = conversation != null && !conversation.IsEnded;

            // if the user is trying to end or finish a conversation 
            if (inConversation && requestedQuit) { 
                conversation.IsEnded = true;
                inConversation = false;
            }

            // start a new conversation if not in one
            if (!inConversation)
            {
                conversation = ConversationFactory.Create(result, intent);
                ConversationHistory.Conversations.Add(conversation);                
            }

            // check and request all required parameters of a conversation
            foreach (ConversationParameter p in conversation.Intent.RequiredParameters)
            {
                if (!TryGetParam(p.ParamName, result, conversation, parameters, p.ParamValidation))
                    return RequestParam(p, conversation, parameters);
            }

            conversation.IsEnded = true;

            return conversation.Intent.Respond(result, parameters, conversation);
        }
        
        public virtual bool TryGetParam(string paramName, LuisResult result, IConversation c, ItemContextParameters parameters, Func<string, ItemContextParameters, IConversation, bool> isParameterValid)
        {
            string value = GetValue(paramName, result, c);
            if (isParameterValid(value, parameters, c))
            {
                if (IsParamRequest(paramName, c)) // clear any request for this property
                    c.Context.Remove(ReqParam);

                c.Context[paramName] = value;
                return true;
            }

            return false;
        }

        public virtual string GetValue(string paramName, LuisResult result, IConversation c)
        {
            var currentEntity = result?.Entities?.FirstOrDefault(x => x.Type.Equals(paramName))?.Entity;
            if (currentEntity != null) // check the current request entities
                return currentEntity;

            if (IsParamRequest(paramName, c)) // was the user responding to a specific request
                return result.Query;

            if (c.Context.ContainsKey(paramName)) // check the context data
                return c.Context[paramName];

            var initialEntity = c.Result?.Entities?.FirstOrDefault(x => x.Type.Equals(paramName))?.Entity;
            if (initialEntity != null) // check the initial request entities
                return initialEntity;

            return string.Empty;
        }

        public virtual bool IsParamRequest(string paramName, IConversation c)
        {
            return c.Context.ContainsKey(ReqParam) && c.Context[ReqParam].Equals(paramName);
        }

        public virtual ConversationResponse RequestParam(ConversationParameter param, IConversation c, ItemContextParameters parameters)
        {
            c.Context[ReqParam] = param.ParamName;

            return ConversationResponseFactory.Create(param.ParamMessage, param.ParamOptions?.Invoke(parameters));
        }
    }
}