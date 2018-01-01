using System;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Speech;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech
{
    public class SpeakerIdentificationService : ISpeakerIdentificationService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ISpeakerIdentificationRepository SpeakerIdentificationRepository;
        protected readonly ILogWrapper Logger;

        public SpeakerIdentificationService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ISpeakerIdentificationRepository speakerIdentificationRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            SpeakerIdentificationRepository = speakerIdentificationRepository;
            Logger = logger;
        }

        public virtual OperationLocation Identify(Stream audioStream, Guid[] ids)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.Identify",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerIdentificationRepository.Identify(audioStream, ids);
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
                    var result = SpeakerIdentificationRepository.CreateProfile(locale);
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
                    SpeakerIdentificationRepository.DeleteProfile(id);
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
                    var result = SpeakerIdentificationRepository.GetProfile(id);
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
                    var result = SpeakerIdentificationRepository.GetProfiles();
                    return result;
                },
                null);
        }

        public virtual OperationLocation Enroll(Stream audioStream, Guid id)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.Enroll",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerIdentificationRepository.Enroll(audioStream, id);
                    return result;
                },
                null);
        }

        public virtual EnrollmentOperation CheckEnrollmentStatus(OperationLocation location)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.CheckEnrollmentStatus",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerIdentificationRepository.CheckEnrollmentStatus(location);
                    return result;
                },
                null);
        }

        public virtual IdentificationOperation CheckIdentificationStatus(OperationLocation location)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpeakerVerificationService.CheckIdentificationStatus",
                ApiKeys.SpeakerRecognitionRetryInSeconds,
                () =>
                {
                    var result = SpeakerIdentificationRepository.CheckIdentificationStatus(location);
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
                    SpeakerIdentificationRepository.ResetEnrollments(id);
                    return true;
                },
                false);
        }
    }
}