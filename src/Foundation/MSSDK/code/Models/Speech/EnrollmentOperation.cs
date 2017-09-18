using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech {
    public class EnrollmentOperation : Operation {
        public Enrollment ProcessingResult { get; set; }
    }
}
