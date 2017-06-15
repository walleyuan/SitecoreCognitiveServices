using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Verification;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class SpeakerVerificationResult
    {
        public CreateProfileResponse NewProfile { get; set; }
        public Enrollment Enrollment { get; set; }
        public VerificationPhrase[] Phrases { get; set; }
        public Profile Profile { get; set; }
        public Profile[] Profiles { get; set; }
        public Verification Verification { get; set; }
    }
}