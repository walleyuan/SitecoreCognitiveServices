using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer {
    public class Adult {
        public bool IsAdultContent { get; set; }

        public bool IsRacyContent { get; set; }

        public double AdultScore { get; set; }

        public double RacyScore { get; set; }
    }
}
