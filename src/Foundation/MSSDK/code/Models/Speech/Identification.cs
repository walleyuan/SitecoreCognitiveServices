using Microsoft.SharedSource.CognitiveServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Speech {
    public class Identification {
        public Guid IdentifiedProfileId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Confidence Confidence { get; set; }
    }
}
