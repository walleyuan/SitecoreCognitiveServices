using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Enums {
    public enum Result {
        Accept,
        Reject,
    }

    public enum EnrollmentStatus {
        Enrolling,
        Training,
        Enrolled,
    }

    public enum Confidence {
        Low,
        Normal,
        High,
    }
}
