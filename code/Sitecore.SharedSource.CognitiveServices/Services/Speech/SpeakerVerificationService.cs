using System;
using System.IO;
using System.Threading.Tasks;
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
                var result = Task.Run(async () => await SpeakerVerificationRepository.VerifyAsync(audioStream, id)).Result;

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
                var result = Task.Run(async () => await SpeakerVerificationRepository.CreateProfileAsync(locale)).Result;
                
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
                Task.Run(async () => await SpeakerVerificationRepository.DeleteProfileAsync(id));
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
                var result = Task.Run(async () => await SpeakerVerificationRepository.GetProfileAsync(id)).Result;
                
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
                var result = Task.Run(async () => await SpeakerVerificationRepository.GetProfilesAsync()).Result;
                
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
                var result = Task.Run(async () => await SpeakerVerificationRepository.GetPhrasesAsync(locale)).Result;
                
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
                var result = Task.Run(async () => await SpeakerVerificationRepository.EnrollAsync(audioStream, id)).Result;
                
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
                Task.Run(async () => await SpeakerVerificationRepository.ResetEnrollmentsAsync(id));
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerVerificationService.ResetEnrollments failed", this, ex);
            }
        }
    }
}