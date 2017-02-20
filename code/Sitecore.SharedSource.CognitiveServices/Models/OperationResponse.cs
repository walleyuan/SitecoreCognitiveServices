using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models 
{
    public class OperationResponse 
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("operationType")]
        public string OperationType { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("operationProcessingResult")]
        public OperationProcessingResult OperationProcessingResult { get; set; }
    }
}