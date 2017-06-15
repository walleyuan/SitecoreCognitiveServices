
using System;
using System.IO;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;

namespace Sitecore.SharedSource.CognitiveServices.Services.Speech
{
    public interface ISpeakerIdentificationService
    {
        OperationLocation Identify(Stream audioStream, Guid[] ids);
        CreateProfileResponse CreateProfile(string locale);
        void DeleteProfile(Guid id);
        Profile GetProfile(Guid id);
        Profile[] GetProfiles();
        OperationLocation Enroll(Stream audioStream, Guid id);
        EnrollmentOperation CheckEnrollmentStatus(OperationLocation location);
        IdentificationOperation CheckIdentificationStatus(OperationLocation location);
        void ResetEnrollments(Guid id);
    }
}