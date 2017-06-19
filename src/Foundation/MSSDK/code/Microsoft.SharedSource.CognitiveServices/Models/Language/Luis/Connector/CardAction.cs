using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis.Connector {
    public class CardAction {
        /// <summary>
        /// Defines the type of action implemented by this button. Defaults to <see cref="F:Microsoft.Bot.Connector.ActionTypes.ImBack"/>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Text description which appear on the button.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// URL Picture which will appear on the button, next to text label.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Supplementary parameter for action. Content of this property
        ///             depends on the ActionType
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the CardAction class.
        /// 
        /// </summary>
        public CardAction() {
            this.Type = "imBack";
        }

        /// <summary>
        /// Initializes a new instance of the CardAction class.
        /// 
        /// </summary>
        public CardAction(string type, string title = null, string image = null, object value = null)
          : this() {
            this.Type = type;
            this.Title = title;
            this.Image = image;
            this.Value = value;
        }
    }
}
