using SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Speech
{
    public class SpeakerVerificationRepository : ISpeakerVerificationRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public SpeakerVerificationRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual CreateProfileResponse CreateProfile(string locale) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles", JsonConvert.SerializeObject(new LocaleSetting { Locale = locale }));

            return JsonConvert.DeserializeObject<CreateProfileResponse>(response);
        }

        public virtual async Task<CreateProfileResponse> CreateProfileAsync(string locale) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles", JsonConvert.SerializeObject(new LocaleSetting { Locale = locale }));

            return JsonConvert.DeserializeObject<CreateProfileResponse>(response);
        }

        public virtual Verification Verify(Stream audioStream, Guid id) {

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verify?verificationProfileId={id.ToString("D")}", audioStream);

            return JsonConvert.DeserializeObject<Verification>(response);
        }

        public virtual async Task<Verification> VerifyAsync(Stream audioStream, Guid id) {

            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verify?verificationProfileId={id.ToString("D")}", audioStream);

            return JsonConvert.DeserializeObject<Verification>(response);
        }

        public virtual Enrollment Enroll(Stream audioStream, Guid id) {

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}/enroll", audioStream);

            return JsonConvert.DeserializeObject<Enrollment>(response);
        }

        public virtual async Task<Enrollment> EnrollAsync(Stream audioStream, Guid id) {

            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}/enroll", audioStream);

            return JsonConvert.DeserializeObject<Enrollment>(response);
        }

        public virtual VerificationPhrase[] GetPhrases(string locale) {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationPhrases?locale={locale}");

            return JsonConvert.DeserializeObject<VerificationPhrase[]>(response);
        }

        public virtual async Task<VerificationPhrase[]> GetPhrasesAsync(string locale) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationPhrases?locale={locale}");

            return JsonConvert.DeserializeObject<VerificationPhrase[]>(response);
        }

        public virtual void ResetEnrollments(Guid id) {

            var response = RepositoryClient.SendTextPost(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}/reset", "");

            return;
        }

        public virtual async Task ResetEnrollmentsAsync(Guid id) {

            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}/reset", "");

            return;
        }

        public virtual void DeleteProfile(Guid id) {

            var response = RepositoryClient.SendJsonDelete(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}");

            return;
        }

        public virtual async Task DeleteProfileAsync(Guid id) {

            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}");

            return;
        }

        public virtual Profile GetProfile(Guid id) {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}");

            return JsonConvert.DeserializeObject<Profile>(response);
        }

        public virtual async Task<Profile> GetProfileAsync(Guid id) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles/{id.ToString("D")}");

            return JsonConvert.DeserializeObject<Profile>(response);
        }

        public virtual Profile[] GetProfiles() {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles");

            return JsonConvert.DeserializeObject<Profile[]>(response);
        }

        public virtual async Task<Profile[]> GetProfilesAsync() {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}verificationProfiles");

            return JsonConvert.DeserializeObject<Profile[]>(response);
        }
    }
}
