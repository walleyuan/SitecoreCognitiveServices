using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Enums {
    public enum Status {
        NotStarted,
        Running,
        Failed,
        Succeeded,
    }

    public enum OperationStatus {
        NotStarted,
        Uploading,
        Running,
        Failed,
        Succeeded,
    }
}
