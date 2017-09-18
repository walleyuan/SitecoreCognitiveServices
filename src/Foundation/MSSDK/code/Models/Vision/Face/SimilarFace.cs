using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face {
    public class SimilarFace {
        public Guid FaceId { get; set; }

        public double Confidence { get; set; }
    }
}
