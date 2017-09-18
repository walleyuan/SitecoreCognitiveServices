using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector {
    public class Activity : IActivity, IConversationUpdateActivity, IContactRelationUpdateActivity, IInstallationUpdateActivity, IMessageActivity, ITypingActivity, IEndOfConversationActivity, IEventActivity, IInvokeActivity {
        /// <summary>
        /// Content-type for an Activity
        /// 
        /// </summary>
        public const string ContentType = "application/vnd.microsoft.activity";

        /// <summary>
        /// Extension data for overflow of properties
        /// 
        /// </summary>
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public JObject Properties { get; set; } = new JObject();

        /// <summary>
        /// The type of the activity
        ///             [message|contactRelationUpdate|converationUpdate|typing|endOfConversation|event|invoke]
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// ID of this activity
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// UTC Time when message was sent (set by service)
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Local time when message was sent (set by client, Ex:
        ///             2016-09-23T13:07:49.4714686-07:00)
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "localTimestamp")]
        public DateTimeOffset? LocalTimestamp { get; set; }

        /// <summary>
        /// Service endpoint where operations concerning the activity may be
        ///             performed
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "serviceUrl")]
        public string ServiceUrl { get; set; }

        /// <summary>
        /// ID of the channel where the activity was sent
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// Sender address
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public ChannelAccount From { get; set; }

        /// <summary>
        /// Conversation
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "conversation")]
        public ConversationAccount Conversation { get; set; }

        /// <summary>
        /// (Outbound to bot only) Bot's address that received the message
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "recipient")]
        public ChannelAccount Recipient { get; set; }

        /// <summary>
        /// Format of text fields [plain|markdown] Default:markdown
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "textFormat")]
        public string TextFormat { get; set; }

        /// <summary>
        /// Hint for how to deal with multiple attachments: [list|carousel]
        ///             Default:list
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "attachmentLayout")]
        public string AttachmentLayout { get; set; }

        /// <summary>
        /// Array of address added
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "membersAdded")]
        public IList<ChannelAccount> MembersAdded { get; set; }

        /// <summary>
        /// Array of addresses removed
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "membersRemoved")]
        public IList<ChannelAccount> MembersRemoved { get; set; }

        /// <summary>
        /// Conversations new topic name
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "topicName")]
        public string TopicName { get; set; }

        /// <summary>
        /// True if the previous history of the channel is disclosed
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "historyDisclosed")]
        public bool? HistoryDisclosed { get; set; }

        /// <summary>
        /// The language code of the Text field
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Content for the message
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// SSML Speak for TTS audio response
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "speak")]
        public string Speak { get; set; }

        /// <summary>
        /// Indicates whether the bot is accepting, expecting, or ignoring
        ///             input
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "inputHint")]
        public string InputHint { get; set; }

        /// <summary>
        /// Text to display if the channel cannot render cards
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// SuggestedActions are used to provide keyboard/quickreply like
        ///             behavior in many clients
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "suggestedActions")]
        public SuggestedActions SuggestedActions { get; set; }

        /// <summary>
        /// Attachments
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "attachments")]
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// Collection of Entity objects, each of which contains metadata
        ///             about this activity. Each Entity object is typed.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "entities")]
        public IList<Entity> Entities { get; set; }

        /// <summary>
        /// Channel-specific payload
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "channelData")]
        public object ChannelData { get; set; }

        /// <summary>
        /// ContactAdded/Removed action
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The original ID this message is a response to
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "replyToId")]
        public string ReplyToId { get; set; }

        /// <summary>
        /// Open-ended value
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        /// <summary>
        /// Name of the operation to invoke or the name of the event
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Reference to another conversation or activity
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "relatesTo")]
        public ConversationReference RelatesTo { get; set; }

        /// <summary>
        /// Code indicating why the conversation has ended
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Initializes a new instance of the Activity class.
        /// 
        /// </summary>
        public Activity() {
            this.Attachments = (IList<Attachment>)new List<Attachment>();
            this.Entities = (IList<Entity>)new List<Entity>();
            this.MembersAdded = (IList<ChannelAccount>)new List<ChannelAccount>();
            this.MembersRemoved = (IList<ChannelAccount>)new List<ChannelAccount>();
        }

        public Activity(string type = null, string id = null, DateTime? timestamp = null, DateTime? localTimestamp = null, string serviceUrl = null, string channelId = null, ChannelAccount from = null, ConversationAccount conversation = null, ChannelAccount recipient = null, string textFormat = null, string attachmentLayout = null, IList<ChannelAccount> membersAdded = null, IList<ChannelAccount> membersRemoved = null, string topicName = null, bool? historyDisclosed = null, string locale = null, string text = null, string speak = null, string inputHint = null, string summary = null, SuggestedActions suggestedActions = null, IList<Attachment> attachments = null, IList<Entity> entities = null, object channelData = null, string action = null, string replyToId = null, object value = null, string name = null, ConversationReference relatesTo = null, string code = null)
          : this() {
            this.Type = type;
            this.Id = id;
            this.Timestamp = timestamp;
            DateTime? nullable = localTimestamp;
            this.LocalTimestamp = nullable.HasValue ? new DateTimeOffset?((DateTimeOffset)nullable.GetValueOrDefault()) : new DateTimeOffset?();
            this.ServiceUrl = serviceUrl;
            this.ChannelId = channelId;
            this.From = from;
            this.Conversation = conversation;
            this.Recipient = recipient;
            this.TextFormat = textFormat;
            this.AttachmentLayout = attachmentLayout;
            this.TopicName = topicName;
            this.HistoryDisclosed = historyDisclosed;
            this.Locale = locale;
            this.Text = text;
            this.Speak = speak;
            this.InputHint = inputHint;
            this.Summary = summary;
            this.SuggestedActions = suggestedActions;
            this.ChannelData = channelData;
            this.Action = action;
            this.ReplyToId = replyToId;
            this.Value = value;
            this.Name = name;
            this.RelatesTo = relatesTo;
            this.Code = code;
            this.MembersAdded = membersAdded ?? (IList<ChannelAccount>)new List<ChannelAccount>();
            this.MembersRemoved = membersRemoved ?? (IList<ChannelAccount>)new List<ChannelAccount>();
            this.Attachments = attachments ?? (IList<Attachment>)new List<Attachment>();
            this.Entities = entities ?? (IList<Entity>)new List<Entity>();
        }

        /// <summary>
        /// Take a message and create a reply message for it with the routing information
        ///             set up to correctly route a reply to the source message
        /// 
        /// </summary>
        /// <param name="text">text you want to reply with</param><param name="locale">language of your reply</param>
        /// <returns>
        /// message set up to route back to the sender
        /// </returns>
        public Activity CreateReply(string text = null, string locale = null) {
            Activity activity = new Activity();
            activity.Type = "message";
            DateTime? nullable = new DateTime?(DateTime.UtcNow);
            activity.Timestamp = nullable;
            ChannelAccount channelAccount1 = new ChannelAccount(this.Recipient.Id, this.Recipient.Name);
            activity.From = channelAccount1;
            ChannelAccount channelAccount2 = new ChannelAccount(this.From.Id, this.From.Name);
            activity.Recipient = channelAccount2;
            string id = this.Id;
            activity.ReplyToId = id;
            string serviceUrl = this.ServiceUrl;
            activity.ServiceUrl = serviceUrl;
            string channelId = this.ChannelId;
            activity.ChannelId = channelId;
            ConversationAccount conversationAccount = new ConversationAccount(this.Conversation.IsGroup, this.Conversation.Id, this.Conversation.Name);
            activity.Conversation = conversationAccount;
            string str1 = text ?? string.Empty;
            activity.Text = str1;
            string str2 = locale ?? this.Locale;
            activity.Locale = str2;
            return activity;
        }

        /// <summary>
        /// Create an instance of the Activity class with IMessageActivity masking
        /// 
        /// </summary>
        public static IMessageActivity CreateMessageActivity() {
            return (IMessageActivity)new Activity("message", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with IContactRelationUpdateActivity masking
        /// 
        /// </summary>
        public static IContactRelationUpdateActivity CreateContactRelationUpdateActivity() {
            return (IContactRelationUpdateActivity)new Activity("contactRelationUpdate", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with IConversationUpdateActivity masking
        /// 
        /// </summary>
        public static IConversationUpdateActivity CreateConversationUpdateActivity() {
            return (IConversationUpdateActivity)new Activity("conversationUpdate", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with ITypingActivity masking
        /// 
        /// </summary>
        public static ITypingActivity CreateTypingActivity() {
            return (ITypingActivity)new Activity("typing", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with IActivity masking
        /// 
        /// </summary>
        public static IActivity CreatePingActivity() {
            return (IActivity)new Activity("ping", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with IEndOfConversationActivity masking
        /// 
        /// </summary>
        public static IEndOfConversationActivity CreateEndOfConversationActivity() {
            return (IEndOfConversationActivity)new Activity("endOfConversation", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with an IEventActivity masking
        /// 
        /// </summary>
        public static IEventActivity CreateEventActivity() {
            return (IEventActivity)new Activity("event", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// Create an instance of the Activity class with IInvokeActivity masking
        /// 
        /// </summary>
        public static IInvokeActivity CreateInvokeActivity() {
            return (IInvokeActivity)new Activity("invoke", (string)null, new DateTime?(), new DateTime?(), (string)null, (string)null, (ChannelAccount)null, (ConversationAccount)null, (ChannelAccount)null, (string)null, (string)null, (IList<ChannelAccount>)null, (IList<ChannelAccount>)null, (string)null, new bool?(), (string)null, (string)null, (string)null, (string)null, (string)null, (SuggestedActions)null, (IList<Attachment>)null, (IList<Entity>)null, (object)null, (string)null, (string)null, (object)null, (string)null, (ConversationReference)null, (string)null);
        }

        /// <summary>
        /// True if the Activity is of the specified activity type
        /// 
        /// </summary>
        protected bool IsActivity(string activity) {
            string type = this.Type;
            string strA;
            if (type == null) {
                strA = (string)null;
            } else {
                char[] chArray = new char[1]
                {
          '/'
                };
                strA = Enumerable.First<string>((IEnumerable<string>)type.Split(chArray));
            }
            string strB = activity;
            int num = 1;
            return string.Compare(strA, strB, num != 0) == 0;
        }

        /// <summary>
        /// Return an IMessageActivity mask if this is a message activity
        /// 
        /// </summary>
        public IMessageActivity AsMessageActivity() {
            if (!this.IsActivity("message"))
                return (IMessageActivity)null;
            return (IMessageActivity)this;
        }

        /// <summary>
        /// Return an IContactRelationUpdateActivity mask if this is a contact relation update activity
        /// 
        /// </summary>
        public IContactRelationUpdateActivity AsContactRelationUpdateActivity() {
            if (!this.IsActivity("contactRelationUpdate"))
                return (IContactRelationUpdateActivity)null;
            return (IContactRelationUpdateActivity)this;
        }

        /// <summary>
        /// Return an IInstallationUpdateActivity mask if this is a installation update activity
        /// 
        /// </summary>
        public IInstallationUpdateActivity AsInstallationUpdateActivity() {
            if (!this.IsActivity("installationUpdate"))
                return (IInstallationUpdateActivity)null;
            return (IInstallationUpdateActivity)this;
        }

        /// <summary>
        /// Return an IConversationUpdateActivity mask if this is a conversation update activity
        /// 
        /// </summary>
        public IConversationUpdateActivity AsConversationUpdateActivity() {
            if (!this.IsActivity("conversationUpdate"))
                return (IConversationUpdateActivity)null;
            return (IConversationUpdateActivity)this;
        }

        /// <summary>
        /// Return an ITypingActivity mask if this is a typing activity
        /// 
        /// </summary>
        public ITypingActivity AsTypingActivity() {
            if (!this.IsActivity("typing"))
                return (ITypingActivity)null;
            return (ITypingActivity)this;
        }

        /// <summary>
        /// Return an IEndOfConversationActivity mask if this is an end of conversation activity
        /// 
        /// </summary>
        public IEndOfConversationActivity AsEndOfConversationActivity() {
            if (!this.IsActivity("endOfConversation"))
                return (IEndOfConversationActivity)null;
            return (IEndOfConversationActivity)this;
        }

        /// <summary>
        /// Return an IEventActivity mask if this is an event activity
        /// 
        /// </summary>
        public IEventActivity AsEventActivity() {
            if (!this.IsActivity("event"))
                return (IEventActivity)null;
            return (IEventActivity)this;
        }

        /// <summary>
        /// Return an IInvokeActivity mask if this is an invoke activity
        /// 
        /// </summary>
        public IInvokeActivity AsInvokeActivity() {
            if (!this.IsActivity("invoke"))
                return (IInvokeActivity)null;
            return (IInvokeActivity)this;
        }

        /// <summary>
        /// Maps type to activity types
        /// 
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The activity type.
        /// </returns>
        public static string GetActivityType(string type) {
            if (string.Equals(type, "message", StringComparison.OrdinalIgnoreCase))
                return "message";
            if (string.Equals(type, "contactRelationUpdate", StringComparison.OrdinalIgnoreCase))
                return "contactRelationUpdate";
            if (string.Equals(type, "conversationUpdate", StringComparison.OrdinalIgnoreCase))
                return "conversationUpdate";
            if (string.Equals(type, "deleteUserData", StringComparison.OrdinalIgnoreCase))
                return "deleteUserData";
            if (string.Equals(type, "typing", StringComparison.OrdinalIgnoreCase))
                return "typing";
            if (string.Equals(type, "ping", StringComparison.OrdinalIgnoreCase))
                return "ping";
            return string.Format("{0}{1}", (object)char.ToLower(type[0]), (object)type.Substring(1));
        }

        /// <summary>
        /// Checks if this (message) activity has content.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// Returns true, if this message has any content to send. False otherwise.
        /// </returns>
        public bool HasContent() {
            return !string.IsNullOrWhiteSpace(this.Text) || !string.IsNullOrWhiteSpace(this.Summary) || this.Attachments != null && Enumerable.Any<Attachment>((IEnumerable<Attachment>)this.Attachments) || this.ChannelData != null;
        }

        /// <summary>
        /// Resolves the mentions from the entities of this (message) activity.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The array of mentions or an empty array, if none found.
        /// </returns>
        public Mention[] GetMentions() {
            IList<Entity> entities = this.Entities;
            return (entities != null ? Enumerable.ToArray<Mention>(Enumerable.Select<Entity, Mention>(Enumerable.Where<Entity>((IEnumerable<Entity>)entities, (Func<Entity, bool>)(entity => string.Compare(entity.Type, "mention", true) == 0)), (Func<Entity, Mention>)(e => e.Properties.ToObject<Mention>()))) : (Mention[])null) ?? new Mention[0];
        }
    }
}
