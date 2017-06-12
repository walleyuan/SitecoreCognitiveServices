using System;
using System.IO;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Verification;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Speech;

namespace Sitecore.SharedSource.CognitiveServices.Services.Speech
{
    public class SpeakerVerificationService : ISpeakerVerificationService
    {
        protected ISpeakerVerificationRepository SpeakerVerificationRepository;
        protected ILogWrapper Logger;

        public SpeakerVerificationService(
            ISpeakerVerificationRepository speakerVerificationRepository,
            ILogWrapper logger)
        {
            SpeakerVerificationRepository = speakerVerificationRepository;
            Logger = logger;
        }

        public virtual Verification Verify(Stream audioStream, Guid id)
        {
            try
            {
                var result = SpeakerVerificationRepository.Verify(audioStream, id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.Verify failed", this, ex);
            }

            return null;
        }

        public virtual CreateProfileResponse CreateProfile(string locale)
        {
            try
            {
                var result = SpeakerVerificationRepository.CreateProfile(locale);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.CreateProfile failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteProfile(Guid id)
        {
            try
            {
                SpeakerVerificationRepository.DeleteProfile(id);
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.DeleteProfile failed", this, ex);
            }
        }

        public virtual Profile GetProfile(Guid id)
        {
            try
            {
                var result = SpeakerVerificationRepository.GetProfile(id);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.GetProfile failed", this, ex);
            }

            return null;
        }

        public virtual Profile[] GetProfiles()
        {
            try
            {
                var result = SpeakerVerificationRepository.GetProfiles();
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.GetProfiles failed", this, ex);
            }

            return null;
        }

        public virtual VerificationPhrase[] GetPhrases(string locale)
        {
            try
            {
                var result = SpeakerVerificationRepository.GetPhrases(locale);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.GetPhrases failed", this, ex);
            }

            return null;
        }

        public virtual Enrollment Enroll(Stream audioStream, Guid id)
        {
            try
            {
                var result = SpeakerVerificationRepository.Enroll(audioStream, id);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.Enroll failed", this, ex);
            }

            return null;
        }

        public virtual void ResetEnrollments(Guid id)
        {
            try
            {
                SpeakerVerificationRepository.ResetEnrollments(id);
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.ResetEnrollments failed", this, ex);
            }
        }
    }
}