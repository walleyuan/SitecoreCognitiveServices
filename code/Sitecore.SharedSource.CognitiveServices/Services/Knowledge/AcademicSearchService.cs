using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge;

namespace Sitecore.SharedSource.CognitiveServices.Services.Knowledge
{
    public class AcademicSearchService : IAcademicSearchService
    {
        protected IAcademicSearchRepository AcademicSearchRepository;
        protected ILogWrapper Logger;

        public AcademicSearchService(
            IAcademicSearchRepository academicSearchRepository,
            ILogWrapper logger)
        {
            AcademicSearchRepository = academicSearchRepository;
            Logger = logger;
        }
        
        public virtual CalcHistogramResponse CalcHistogram(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0)
        {
            try
            {
                var result = Task.Run(async () => await AcademicSearchRepository.CalcHistogramAsync(expression, model, attributes, count, offset)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AcademicSearchService.CalcHistogram failed", this, ex);
            }

            return null;
        }

        public virtual EvaluateResponse Evaluate(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "")
        {
            try
            {
                var result = Task.Run(async () => await AcademicSearchRepository.EvaluateAsync(expression, model, count, offset, attributes, orderby)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AcademicSearchService.Evaluate failed", this, ex);
            }

            return null;
        }
        
        public virtual GraphSearchResponse GraphSearch(GraphSearchRequest request)
        {
            try
            {
                var result = Task.Run(async () => await AcademicSearchRepository.GraphSearchAsync(request)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AcademicSearchService.GraphSearch failed", this, ex);
            }

            return null;
        }

        public virtual InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest)
        {
            try
            {
                var result = Task.Run(async () => await AcademicSearchRepository.InterpretAsync(query, complete, count, offset, timeout, model)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AcademicSearchService.Interpret failed", this, ex);
            }

            return null;
        }
        
        public virtual double Similarity(string s1, string s2)
        {
            try
            {
                var result = Task.Run(async () => await AcademicSearchRepository.SimilarityAsync(s1, s2)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AcademicSearchService.Similarity failed", this, ex);
            }

            return 0f;            
        }
    }
}