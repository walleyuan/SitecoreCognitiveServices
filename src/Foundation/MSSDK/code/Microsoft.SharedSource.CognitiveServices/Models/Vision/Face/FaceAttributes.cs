using Microsoft.SharedSource.CognitiveServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Face {
    public class FaceAttributes {
        public double Age { get; set; }

        public string Gender { get; set; }

        public HeadPose HeadPose { get; set; }

        public double Smile { get; set; }

        public FacialHair FacialHair { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Glasses Glasses { get; set; }
    }
}
