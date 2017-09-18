using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech {
    public class EnrollmentBase {
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentStatus EnrollmentStatus { get; set; }
    }
}
