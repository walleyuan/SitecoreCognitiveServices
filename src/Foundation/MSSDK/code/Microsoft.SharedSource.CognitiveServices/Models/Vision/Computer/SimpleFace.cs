using Microsoft.SharedSource.CognitiveServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer {
    public class SimpleFace {
        public int Age { get; set; }

        public string Gender { get; set; }

        public Rectangle FaceRectangle { get; set; }
    }
}
