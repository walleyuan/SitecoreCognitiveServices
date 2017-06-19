using Microsoft.SharedSource.CognitiveServices.Models.Speech;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Speech
{
    public interface ISpeakerVerificationRepository
    {
        Verification Verify(Stream audioStream, Guid id);
        Task<Verification> VerifyAsync(Stream audioStream, Guid id);

        CreateProfileResponse CreateProfile(string locale);
        Task<CreateProfileResponse> CreateProfileAsync(string locale);

        void DeleteProfile(Guid id);
        Task DeleteProfileAsync(Guid id);

        Profile GetProfile(Guid id);
        Task<Profile> GetProfileAsync(Guid id);

        Profile[] GetProfiles();
        Task<Profile[]> GetProfilesAsync();

        VerificationPhrase[] GetPhrases(string locale);
        Task<VerificationPhrase[]> GetPhrasesAsync(string locale);

        Enrollment Enroll(Stream audioStream, Guid id);
        Task<Enrollment> EnrollAsync(Stream audioStream, Guid id);

        void ResetEnrollments(Guid id);
        Task ResetEnrollmentsAsync(Guid id);
    }
}
