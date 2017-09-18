using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face {
    public class TrainingStatus {
        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public string Message { get; set; }
    }
}
