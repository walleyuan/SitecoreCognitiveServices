using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
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