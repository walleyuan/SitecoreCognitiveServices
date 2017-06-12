using System;
using System.IO;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Speech;

namespace Sitecore.SharedSource.CognitiveServices.Services.Speech
{
    public class SpeakerIdentificationService : ISpeakerIdentificationService
    {
        protected ISpeakerIdentificationRepository SpeakerIdentificationRepository;
        protected ILogWrapper Logger;

        public SpeakerIdentificationService(
            ISpeakerIdentificationRepository speakerIdentificationRepository,
            ILogWrapper logger)
        {
            SpeakerIdentificationRepository = speakerIdentificationRepository;
            Logger = logger;
        }

        public virtual OperationLocation Identify(Stream audioStream, Guid[] ids)
        {
            try
            {
                var result = SpeakerIdentificationRepository.Identify(audioStream, ids);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.Identify failed", this, ex);
            }

            return null;
        }

        public virtual CreateProfileResponse CreateProfile(string locale) {
            try
            {
                var result = SpeakerIdentificationRepository.CreateProfile(locale);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.CreateProfile failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteProfile(Guid id) {
            try
            {
                SpeakerIdentificationRepository.DeleteProfile(id);
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.DeleteProfile failed", this, ex);
            }
        }

        public virtual Profile GetProfile(Guid id) {
            try
            {
                var result = SpeakerIdentificationRepository.GetProfile(id);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.GetProfile failed", this, ex);
            }

            return null;
        }

        public virtual Profile[] GetProfiles() {
            try
            {
                var result = SpeakerIdentificationRepository.GetProfiles();
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.GetProfiles failed", this, ex);
            }

            return null;
        }

        public virtual OperationLocation Enroll(Stream audioStream, Guid id) {
            try
            {
                var result = SpeakerIdentificationRepository.Enroll(audioStream, id);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.Enroll failed", this, ex);
            }

            return null;
        }

        public virtual EnrollmentOperation CheckEnrollmentStatus(OperationLocation location) {
            try
            {
                var result = SpeakerIdentificationRepository.CheckEnrollmentStatus(location);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.CheckEnrollmentStatus failed", this, ex);
            }

            return null;
        }

        public virtual IdentificationOperation CheckIdentificationStatus(OperationLocation location) {
            try
            {
                var result = SpeakerIdentificationRepository.CheckIdentificationStatus(location);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.CheckIdentificationStatus failed", this, ex);
            }

            return null;
        }

        public virtual void ResetEnrollments(Guid id) {
            try
            {
                SpeakerIdentificationRepository.ResetEnrollments(id);
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.Something failed", this, ex);
            }
        }
    }
}