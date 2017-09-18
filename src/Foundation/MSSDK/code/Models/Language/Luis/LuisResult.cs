using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class LuisResult {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "topScoringIntent")]
        public IntentRecommendation TopScoringIntent { get; set; }

        [JsonProperty(PropertyName = "intents")]
        public IList<IntentRecommendation> Intents { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public IList<EntityRecommendation> Entities { get; set; }

        [JsonProperty(PropertyName = "compositeEntities")]
        public IList<CompositeEntity> CompositeEntities { get; set; }

        [JsonProperty(PropertyName = "dialog")]
        public DialogResponse Dialog { get; set; }

        [JsonProperty(PropertyName = "alteredQuery")]
        public string AlteredQuery { get; set; }

        public LuisResult() {
        }

        public LuisResult(string query, IList<EntityRecommendation> entities, IntentRecommendation topScoringIntent = null, IList<IntentRecommendation> intents = null, IList<CompositeEntity> compositeEntities = null, DialogResponse dialog = null, string alteredQuery = null) {
            this.Query = query;
            this.TopScoringIntent = topScoringIntent;
            this.Intents = intents;
            this.Entities = entities;
            this.CompositeEntities = compositeEntities;
            this.Dialog = dialog;
            this.AlteredQuery = alteredQuery;
        }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// 
        /// </summary>
        public virtual void Validate() {
            if (this.Query == null)
                throw new Exception("Query Cannot Be Null");
            if (this.Entities == null)
                throw new Exception("Entities Cannot Be Null");
            if (this.Entities != null) {
                foreach (EntityRecommendation entityRecommendation in (IEnumerable<EntityRecommendation>)this.Entities) {
                    if (entityRecommendation != null)
                        entityRecommendation.Validate();
                }
            }
            if (this.CompositeEntities == null)
                return;
            foreach (CompositeEntity compositeEntity in (IEnumerable<CompositeEntity>)this.CompositeEntities) {
                if (compositeEntity != null)
                    compositeEntity.Validate();
            }
        }
    }
}