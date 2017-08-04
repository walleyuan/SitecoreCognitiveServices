using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator
{
    public class PersonalIdentifiableInformation
    {
        public List<PersonalIdentifiableInformationSet> Email { get; set; }
        /// <summary>
        /// Initial Privacy Assessment
        /// </summary>
        public List<PersonalIdentifiableInformationSet> IPA { get; set; }
        public List<PersonalIdentifiableInformationSet> Phone { get; set; }
        public List<PersonalIdentifiableInformationSet> Address { get; set; }
    }
}