using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.EntityLinking {
    [DataContract]
    public class Match {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "entries")]
        public IList<Entry> Entries { get; set; }
    }
}
