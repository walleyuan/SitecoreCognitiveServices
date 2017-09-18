using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech {
    public class Identification {
        public Guid IdentifiedProfileId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Confidence Confidence { get; set; }
    }
}
