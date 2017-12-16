using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier;
using SitecoreCognitiveServices.Foundation.IBMSDK.Repositories;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class NaturalLanguageClassifierService : INaturalLanguageClassifierService
    {
        protected INaturalLanguageClassifierRepository NaturalLanguageClassifierRepository;
        protected ILogWrapper Logger;

        public NaturalLanguageClassifierService(
            INaturalLanguageClassifierRepository naturalLanguageClassifierRepository,
            ILogWrapper logger)
        {
            NaturalLanguageClassifierRepository = naturalLanguageClassifierRepository;
            Logger = logger;
        }

        public virtual ClassifyResponse Classify(string classifier_id, string text)
        {
            try
            {
                var result = NaturalLanguageClassifierRepository.Classify(classifier_id, text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("NaturalLanguageClassifierService.Classify failed", this, ex);
            }

            return null;
        }

        public virtual CreateClassifierResponse CreateClassifier(string classifier_id, string training_data_language, string training_data)
        {
            try
            {
                var result = NaturalLanguageClassifierRepository.CreateClassifier(classifier_id, training_data_language, training_data);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("NaturalLanguageClassifierService.CreateClassifier failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteClassifier(string classifier_id)
        {
            try
            {
                NaturalLanguageClassifierRepository.DeleteClassifier(classifier_id);
            }
            catch (Exception ex)
            {
                Logger.Error("NaturalLanguageClassifierService.DeleteClassifier failed", this, ex);
            }

            return;
        }

        public virtual GetClassifierInfoResponse GetClassifierInfo(string classifier_id)
        {
            try
            {
                var result = NaturalLanguageClassifierRepository.GetClassifierInfo(classifier_id);
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("NaturalLanguageClassifierService.GetClassifierInfo failed", this, ex);
            }

            return null;
        }

        public virtual ListClassifierResponse ListClassifiers()
        {
            try
            {
                var result = NaturalLanguageClassifierRepository.ListClassifiers();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("NaturalLanguageClassifierService.ListClassifiers failed", this, ex);
            }

            return null;
        }
    }
}