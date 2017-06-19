using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis.Connector {
    public class SuggestedActions {
        /// <summary>
        /// Ids of the recipients that the actions should be shown to.  These
        ///             Ids are relative to the channelId and a subset of all recipients
        ///             of the activity
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public IList<string> To { get; set; }

        /// <summary>
        /// Actions that can be shown to the user
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "actions")]
        public IList<CardAction> Actions { get; set; }

        /// <summary>
        /// Initializes a new instance of the SuggestedActions class.
        /// 
        /// </summary>
        public SuggestedActions() {
        }

        public SuggestedActions(IList<string> to = null, IList<CardAction> actions = null) {
            this.To = to;
            this.Actions = actions;
        }
    }
}
