using SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech;
using System;
using System.IO;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Speech
{
    public interface ISpeakerVerificationService
    {
        Verification Verify(Stream audioStream, Guid id);
        CreateProfileResponse CreateProfile(string locale);
        void DeleteProfile(Guid id);
        Profile GetProfile(Guid id);
        Profile[] GetProfiles();
        VerificationPhrase[] GetPhrases(string locale);
        Enrollment Enroll(Stream audioStream, Guid id);
        void ResetEnrollments(Guid id);
    }
}