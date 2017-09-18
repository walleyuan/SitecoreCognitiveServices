using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.EntityLinking {
    [DataContract]
    public class EntityLink {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "wikipediaId")]
        public string WikipediaID { get; set; }

        [DataMember(Name = "matches")]
        public IList<Match> Matches { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}
