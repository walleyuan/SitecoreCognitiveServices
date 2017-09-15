using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
{
    public abstract class BaseIntent : IIntent
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        
        public abstract ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation);

        #region Base Intent

        protected readonly IOleSettings Settings;
        public virtual Guid ApplicationId => Settings.OleApplicationId;
        public virtual List<ConversationParameter> RequiredParameters => new List<ConversationParameter>();
        protected string ReqParam = "RequestParam";

        protected BaseIntent(IOleSettings settings)
        {
            Settings = settings;
        }
        
        public virtual ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            foreach (ConversationParameter p in RequiredParameters)
            {
                if (!TryGetParam(p.ParamName, result, conversation, parameters, p.ParamValidation))
                    return RequestParam(p, conversation);
            }

            conversation.IsEnded = true;

            return ProcessResponse(result, parameters, conversation);
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

        public virtual ConversationResponse RequestParam(ConversationParameter param, IConversation c)
        {
            c.Context[ReqParam] = param.ParamName;

            return new ConversationResponse
            {
                Message = param.ParamMessage,
                Options = param.ParamOptions?.Invoke()
            };
        }

        public virtual ConversationResponse CreateConversationResponse(string message)
        {
            return new ConversationResponse
            {
                Message = message
            };
        }

        #endregion
    }
}