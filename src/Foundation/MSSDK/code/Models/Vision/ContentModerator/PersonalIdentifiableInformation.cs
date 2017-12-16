using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator
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