using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.IBMSDK.Models.NaturalLanguageClassifier;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Repositories
{
    public class NaturalLanguageClassifierRepository : INaturalLanguageClassifierRepository
    {
        protected static readonly string classifyUrl = "/classify";
        
        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public NaturalLanguageClassifierRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }
        
        #region Create Classifier

        /// <summary>
        /// POST /v1/classifiers
        /// </summary>
        /// <param name="training_data">(Required) Training data. Each text value must have at least one class. The data can include up to 15,000 records. For details, see https://www.ibm.com/watson/developercloud/doc/natural-language-classifier/using-your-data.html</param>
        /// <param name="training_metadata">The metadata identifies the required language of the data and an optional name to identify the classifier. Specify the language with the 2-letter primary language code as assigned in ISO standard 639. Supported languages are English (en), Arabic (ar), French (fr), German, (de), Italian (it), Japanese (ja), Korean (ko), Brazilian Portuguese (pt), and Spanish (es).</param>
        /// <returns></returns>
        public virtual CreateClassifierResponse CreateClassifier(string classifier_name, string training_data_language, string training_data)
        {
            TrainingMetadataEntity trainingMetadata = new TrainingMetadataEntity()
            {
                name = classifier_name,
                language = training_data_language
            };

            var response = RepositoryClient.SendJsonPost(ApiKeys.NaturalLanguageClassifierUsername, 
                ApiKeys.NaturalLanguageClassifierPassword, 
                ApiKeys.NaturalLanguageClassifierEndpoint, 
                JsonConvert.SerializeObject(trainingMetadata));

            return JsonConvert.DeserializeObject<CreateClassifierResponse>(response);
        }

        #endregion

        #region List Classifiers

        /// <summary>
        /// GET /v1/classifiers
        /// </summary>
        /// <param name="classifiers">An array [ClassifierInfoPayload] of classifiers that are available for the service instance. Returns an empty array if no classifiers are available.</param>
        /// <returns></returns>
        public virtual ListClassifierResponse ListClassifiers()
        {
            var response = RepositoryClient.SendGet(ApiKeys.NaturalLanguageClassifierUsername, 
                ApiKeys.NaturalLanguageClassifierPassword,
                ApiKeys.NaturalLanguageClassifierEndpoint);

            return JsonConvert.DeserializeObject<ListClassifierResponse>(response);
        }

        #endregion

        #region Get Classifier Info

        /// <summary>
        /// GET /v1/classifiers/{classifier_id}
        /// </summary>
        /// <param name="classifier_id">(Required) Classifier ID to query</param>
        /// <returns></returns>
        public virtual GetClassifierInfoResponse GetClassifierInfo(string classifier_id)
        {
            var response = RepositoryClient.SendGet(ApiKeys.NaturalLanguageClassifierUsername, 
                ApiKeys.NaturalLanguageClassifierPassword,
                $"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}");

            return JsonConvert.DeserializeObject<GetClassifierInfoResponse>(response);
        }

        #endregion

        #region Delete Classifier

        /// <summary>
        /// DELETE /v1/classifiers/{classifier_id}
        /// </summary>
        /// <param name="classifier_id">(Required) Classifier ID to delete</param>
        /// <returns></returns>
        public virtual void DeleteClassifier(string classifier_id)
        {
            RepositoryClient.SendJsonDelete(ApiKeys.NaturalLanguageClassifierUsername, 
                ApiKeys.NaturalLanguageClassifierPassword,
                $"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}");
        }

        #endregion

        #region Classify

        /// <summary>
        /// GET /v1/classifiers/{classifier_id}/classify
        /// POST /v1/classifiers/{classifier_id}/classify : {\"text\":\"How hot will it be today?\"}
        /// </summary>
        /// <param name="classifier_id">(Required) Classifier ID to use</param>
        /// <param name="text">(Required) Phrase to classify</param>
        /// <returns></returns>
        public virtual ClassifyResponse Classify(string classifier_id, string text)
        {
            TextEntity textEntity = new TextEntity()
            {
                Text = text
            };

            var response = RepositoryClient.SendJsonPost(ApiKeys.NaturalLanguageClassifierUsername, 
                ApiKeys.NaturalLanguageClassifierPassword,
                $"{ApiKeys.NaturalLanguageClassifierEndpoint}{classifier_id}{classifyUrl}",
                JsonConvert.SerializeObject(textEntity));
            
            return JsonConvert.DeserializeObject<ClassifyResponse>(response);
        }

        #endregion
    }
}