using System.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Speech;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Speech
{
    public class SpeakerIdentificationRepository : ISpeakerIdentificationRepository
    {
        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public SpeakerIdentificationRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual CreateProfileResponse CreateProfile(string locale) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles", JsonConvert.SerializeObject(new LocaleSetting { Locale = locale }));

            return JsonConvert.DeserializeObject<CreateProfileResponse>(response);
        }

        public virtual async Task<CreateProfileResponse> CreateProfileAsync(string locale) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles", JsonConvert.SerializeObject(new LocaleSetting { Locale = locale }));

            return JsonConvert.DeserializeObject<CreateProfileResponse>(response);
        }

        public virtual Profile GetProfile(Guid id) {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}");

            return JsonConvert.DeserializeObject<Profile>(response);
        }

        public virtual async Task<Profile> GetProfileAsync(Guid id) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}");

            return JsonConvert.DeserializeObject<Profile>(response);
        }

        public virtual OperationLocation Identify(Stream audioStream, Guid[] ids, bool forceShortAudio = false) {

            var idList = string.Join(",", ids.Select(a => a.ToString("D")));

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identify?identificationProfileIds={idList}&shortAudio={forceShortAudio}");

            return JsonConvert.DeserializeObject<OperationLocation>(response);
        }

        public virtual async Task<OperationLocation> IdentifyAsync(Stream audioStream, Guid[] ids, bool forceShortAudio = false) {

            var idList = string.Join(",", ids.Select(a => a.ToString("D")));

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identify?identificationProfileIds={idList}&shortAudio={forceShortAudio}");

            return JsonConvert.DeserializeObject<OperationLocation>(response);
        }

        public virtual OperationLocation Enroll(Stream audioStream, Guid id, bool forceShortAudio = false) {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}/enroll?shortAudio={forceShortAudio}");

            return JsonConvert.DeserializeObject<OperationLocation>(response);
        }

        public virtual async Task<OperationLocation> EnrollAsync(Stream audioStream, Guid id, bool forceShortAudio = false) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}/enroll?shortAudio={forceShortAudio}");

            return JsonConvert.DeserializeObject<OperationLocation>(response);
        }

        public virtual IdentificationOperation CheckIdentificationStatus(OperationLocation location) {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, location.Url);

            return JsonConvert.DeserializeObject<IdentificationOperation>(response);
        }

        public virtual async Task<IdentificationOperation> CheckIdentificationStatusAsync(OperationLocation location) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, location.Url);

            return JsonConvert.DeserializeObject<IdentificationOperation>(response);
        }

        public virtual EnrollmentOperation CheckEnrollmentStatus(OperationLocation location) {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, location.Url);

            return JsonConvert.DeserializeObject<EnrollmentOperation>(response);
        }

        public virtual async Task<EnrollmentOperation> CheckEnrollmentStatusAsync(OperationLocation location) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, location.Url);

            return JsonConvert.DeserializeObject<EnrollmentOperation>(response);
        }

        public virtual Profile[] GetProfiles() {

            var response = RepositoryClient.SendGet(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles");

            return JsonConvert.DeserializeObject<Profile[]>(response);
        }

        public virtual async Task<Profile[]> GetProfilesAsync() {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles");

            return JsonConvert.DeserializeObject<Profile[]>(response);
        }

        public virtual void ResetEnrollments(Guid id) {

            var response = RepositoryClient.SendTextPost(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}/reset", "");

            return;
        }

        public virtual async Task ResetEnrollmentsAsync(Guid id) {

            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}/reset", "");

            return;
        }

        public virtual void DeleteProfile(Guid id) {

            var response = RepositoryClient.SendJsonDelete(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}");

            return;
        }

        public virtual async Task DeleteProfileAsync(Guid id) {

            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.SpeakerRecognition, $"{ApiKeys.SpeakerRecognition}identificationProfiles/{id.ToString("D")}");

            return;
        }
    }
}
