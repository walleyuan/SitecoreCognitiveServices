using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector {
    public interface IConversationUpdateActivity : IActivity {
        /// <summary>
        /// Members added to the conversation
        /// 
        /// </summary>
        IList<ChannelAccount> MembersAdded { get; set; }

        /// <summary>
        /// Members removed from the conversation
        /// 
        /// </summary>
        IList<ChannelAccount> MembersRemoved { get; set; }

        /// <summary>
        /// The conversation's updated topic name
        /// 
        /// </summary>
        string TopicName { get; set; }

        /// <summary>
        /// True if prior history of the channel is disclosed
        /// 
        /// </summary>
        bool? HistoryDisclosed { get; set; }
    }
}
