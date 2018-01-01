using System;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Speech;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech
{
    public class SpeakerVerificationService : ISpeakerVerificationService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ISpeakerVerificationRepository SpeakerVerificationRepository;
        protected readonly ILogWrapper Logger;

        public SpeakerVerificationService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ISpeakerVerificationRepository speakerVerificationRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            SpeakerVerificationRepository = speakerVerificationRepository;
            Logger = logger;
        }

        public virtual Verification Verify(Stream audioStream, Guid id)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.Verify",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerVerificationRepository.Verify(audioStream, id);
                    return result;
                },
                null);
        }

        public virtual CreateProfileResponse CreateProfile(string locale)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.CreateProfile",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerVerificationRepository.CreateProfile(locale);
                    return result;
                },
                null);
        }

        public virtual void DeleteProfile(Guid id)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.DeleteProfile",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    SpeakerVerificationRepository.DeleteProfile(id);
                    return true;
                },
                false);
        }

        public virtual Profile GetProfile(Guid id)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.GetProfile",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerVerificationRepository.GetProfile(id);
                    return result;
                },
                null);
        }

        public virtual Profile[] GetProfiles()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.GetProfiles",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerVerificationRepository.GetProfiles();
                    return result;
                },
                null);
        }

        public virtual VerificationPhrase[] GetPhrases(string locale)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.GetPhrases",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerVerificationRepository.GetPhrases(locale);
                    return result;
                },
                null);
        }

        public virtual Enrollment Enroll(Stream audioStream, Guid id)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.Enroll",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerVerificationRepository.Enroll(audioStream, id);
                    return result;
                },
                null);
        }

        public virtual void ResetEnrollments(Guid id)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.ResetEnrollments",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    SpeakerVerificationRepository.ResetEnrollments(id);
                    return true;
                },
                false);
        }
    }
}