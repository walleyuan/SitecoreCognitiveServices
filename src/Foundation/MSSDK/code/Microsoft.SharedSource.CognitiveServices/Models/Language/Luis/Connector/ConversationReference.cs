using Newtonsoft.Json;
using System;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis.Connector {
    public class ConversationReference : IEquatable<ConversationReference> {
        /// <summary>
        /// (Optional) ID of the activity to refer to
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "activityId")]
        public string ActivityId { get; set; }

        /// <summary>
        /// (Optional) User participating in this conversation
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public ChannelAccount User { get; set; }

        /// <summary>
        /// Bot participating in this conversation
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "bot")]
        public ChannelAccount Bot { get; set; }

        /// <summary>
        /// Conversation reference
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "conversation")]
        public ConversationAccount Conversation { get; set; }

        /// <summary>
        /// Channel ID
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// Service endpoint where operations concerning the referenced
        ///             conversation may be performed
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "serviceUrl")]
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Initializes a new instance of the ConversationReference class.
        /// 
        /// </summary>
        public ConversationReference() {
        }

        /// <summary>
        /// Initializes a new instance of the ConversationReference class.
        /// 
        /// </summary>
        public ConversationReference(string activityId = null, ChannelAccount user = null, ChannelAccount bot = null, ConversationAccount conversation = null, string channelId = null, string serviceUrl = null) {
            this.ActivityId = activityId;
            this.User = user;
            this.Bot = bot;
            this.Conversation = conversation;
            this.ChannelId = channelId;
            this.ServiceUrl = serviceUrl;
        }

        /// <summary>
        /// Creates <see cref="T:Microsoft.Bot.Connector.Activity"/> from conversation reference as it is posted to bot.
        /// 
        /// </summary>
        public Activity GetPostToBotMessage() {
            Activity activity = new Activity();
            activity.Type = "message";
            string str = Guid.NewGuid().ToString();
            activity.Id = str;
            activity.Recipient = new ChannelAccount() {
                Id = this.Bot.Id,
                Name = this.Bot.Name
            };
            string channelId = this.ChannelId;
            activity.ChannelId = channelId;
            string serviceUrl = this.ServiceUrl;
            activity.ServiceUrl = serviceUrl;
            activity.Conversation = new ConversationAccount() {
                Id = this.Conversation.Id,
                IsGroup = this.Conversation.IsGroup,
                Name = this.Conversation.Name
            };
            activity.From = new ChannelAccount() {
                Id = this.User.Id,
                Name = this.User.Id
            };
            return activity;
        }

        /// <summary>
        /// Creates <see cref="T:Microsoft.Bot.Connector.Activity"/> from conversation reference that can be posted to user as reply.
        /// 
        /// </summary>
        public Activity GetPostToUserMessage() {
            Activity postToBotMessage = this.GetPostToBotMessage();
            ChannelAccount recipient = postToBotMessage.Recipient;
            ChannelAccount from = postToBotMessage.From;
            ChannelAccount channelAccount1 = recipient;
            postToBotMessage.From = channelAccount1;
            ChannelAccount channelAccount2 = from;
            postToBotMessage.Recipient = channelAccount2;
            return postToBotMessage;
        }

        public bool Equals(ConversationReference other) {
            if (other != null && object.Equals((object)this.User, (object)other.User) && (object.Equals((object)this.Bot, (object)other.Bot) && object.Equals((object)this.Conversation, (object)other.Conversation)) && this.ChannelId == other.ChannelId)
                return this.ServiceUrl == other.ServiceUrl;
            return false;
        }

        public override bool Equals(object other) {
            return this.Equals(other as ConversationReference);
        }

        public override int GetHashCode() {
            return this.User.GetHashCode() ^ this.Bot.GetHashCode() ^ this.Conversation.GetHashCode() ^ this.ServiceUrl.GetHashCode() ^ this.ChannelId.GetHashCode();
        }
    }
}
