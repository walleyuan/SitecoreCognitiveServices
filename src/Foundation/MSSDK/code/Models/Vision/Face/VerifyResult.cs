using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Face {
    public class VerifyResult {
        public bool IsIdentical { get; set; }

        public double Confidence { get; set; }
    }
}
