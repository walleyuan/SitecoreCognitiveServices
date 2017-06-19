using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class DialogResponse {
        /// <summary>
        /// Prompt that should be asked.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// Name of the parameter.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "parameterName")]
        public string ParameterName { get; set; }

        /// <summary>
        /// Type of the parameter.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "parameterType")]
        public string ParameterType { get; set; }

        /// <summary>
        /// The context id for dialog.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "contextId")]
        public string ContextId { get; set; }

        /// <summary>
        /// The dialog status. Possible values include: 'Question', 'Finished'
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the DialogResponse class.
        /// 
        /// </summary>
        public DialogResponse() {
        }

        /// <summary>
        /// Initializes a new instance of the DialogResponse class.
        /// 
        /// </summary>
        public DialogResponse(string prompt = null, string parameterName = null, string parameterType = null, string contextId = null, string status = null) {
            this.Prompt = prompt;
            this.ParameterName = parameterName;
            this.ParameterType = parameterType;
            this.ContextId = contextId;
            this.Status = status;
        }

        /// <summary>
        /// Possible values for <see cref="P:Microsoft.Bot.Builder.Luis.Models.DialogResponse.Status"/>
        /// </summary>
        public static class DialogStatus {
            /// <summary>
            /// Send the prompt in <see cref="P:Microsoft.Bot.Builder.Luis.Models.DialogResponse.Prompt"/>
            /// </summary>
            public const string Question = "Question";
            /// <summary>
            /// Dialog is finished.
            /// 
            /// </summary>
            public const string Finished = "Finished";
        }
    }
}
