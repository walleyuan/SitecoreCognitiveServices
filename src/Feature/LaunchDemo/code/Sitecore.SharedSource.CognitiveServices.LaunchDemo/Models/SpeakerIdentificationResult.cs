using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class SpeakerIdentificationResult
    {
        public Profile[] Profiles { get; set; }
        public Profile Profile { get; set; }
        public CreateProfileResponse NewProfile { get; set; }
        public OperationLocation EnrollOperation { get; set; }
        public IdentificationOperation IdentificationStatus { get; set; }
        public EnrollmentOperation EnrollmentStatus { get; set; }
        public OperationLocation IdentifyOperation { get; set; }
    }
}