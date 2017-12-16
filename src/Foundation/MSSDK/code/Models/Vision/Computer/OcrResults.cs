using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer {
    public class OcrResults {
        public string Language { get; set; }

        public double? TextAngle { get; set; }

        public string Orientation { get; set; }

        public Region[] Regions { get; set; }
    }
}
