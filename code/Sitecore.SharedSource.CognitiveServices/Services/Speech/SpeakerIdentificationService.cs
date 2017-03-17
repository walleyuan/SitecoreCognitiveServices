using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Repositories.Speech;

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
                var result = Task.Run(async () => await SpeakerIdentificationRepository.IdentifyAsync(audioStream, ids)).Result;
                
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
                var result = Task.Run(async () => await SpeakerIdentificationRepository.CreateProfileAsync(locale)).Result;
                
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
                Task.Run(async () => await SpeakerIdentificationRepository.DeleteProfileAsync(id));
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.DeleteProfile failed", this, ex);
            }
        }

        public virtual Profile GetProfile(Guid id) {
            try
            {
                var result = Task.Run(async () => await SpeakerIdentificationRepository.GetProfileAsync(id)).Result;
                
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
                var result = Task.Run(async () => await SpeakerIdentificationRepository.GetProfilesAsync()).Result;
                
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
                var result = Task.Run(async () => await SpeakerIdentificationRepository.EnrollAsync(audioStream, id)).Result;
                
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
                var result = Task.Run(async () => await SpeakerIdentificationRepository.CheckEnrollmentStatusAsync(location)).Result;
                
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
                var result = Task.Run(async () => await SpeakerIdentificationRepository.CheckIdentificationStatusAsync(location)).Result;
                
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
                Task.Run(async () => await SpeakerIdentificationRepository.ResetEnrollmentsAsync(id));
            }
            catch (Exception ex)
            {
                Logger.Error("SpeakerIdentificationService.Something failed", this, ex);
            }
        }
    }
}