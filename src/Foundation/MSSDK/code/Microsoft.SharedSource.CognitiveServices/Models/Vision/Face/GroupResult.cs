using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Face {
    public class GroupResult {
        public List<Guid[]> Groups { get; set; }

        public Guid[] MessyGroup { get; set; }
    }
}
