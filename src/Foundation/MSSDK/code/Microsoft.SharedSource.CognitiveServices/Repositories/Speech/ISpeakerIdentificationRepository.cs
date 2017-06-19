using Microsoft.SharedSource.CognitiveServices.Models.Speech;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Speech
{
    public interface ISpeakerIdentificationRepository
    {
        OperationLocation Identify(Stream audioStream, Guid[] ids, bool forceShortAudio = false);
        Task<OperationLocation> IdentifyAsync(Stream audioStream, Guid[] ids, bool forceShortAudio = false);

        CreateProfileResponse CreateProfile(string locale);
        Task<CreateProfileResponse> CreateProfileAsync(string locale);

        void DeleteProfile(Guid id);
        Task DeleteProfileAsync(Guid id);

        Profile GetProfile(Guid id);
        Task<Profile> GetProfileAsync(Guid id);

        Profile[] GetProfiles();
        Task<Profile[]> GetProfilesAsync();

        OperationLocation Enroll(Stream audioStream, Guid id, bool forceShortAudio = false);
        Task<OperationLocation> EnrollAsync(Stream audioStream, Guid id, bool forceShortAudio = false);

        EnrollmentOperation CheckEnrollmentStatus(OperationLocation location);
        Task<EnrollmentOperation> CheckEnrollmentStatusAsync(OperationLocation location);

        IdentificationOperation CheckIdentificationStatus(OperationLocation location);
        Task<IdentificationOperation> CheckIdentificationStatusAsync(OperationLocation location);

        void ResetEnrollments(Guid id);
        Task ResetEnrollmentsAsync(Guid id);
    }
}
