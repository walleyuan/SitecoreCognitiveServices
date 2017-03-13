using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Video.Contract;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class VideoResult
    {
        public Operation Operation { get; set; }
        public OperationResult OperationResult { get; set; }

        private FaceDetectionResult _fdr { get; set; }
        public FaceDetectionResult FaceDetectionResult
        {
            get
            {
                if (OperationResult?.ProcessingResult == null)
                    return null;

                if(_fdr == null)
                    _fdr = JsonConvert.DeserializeObject<FaceDetectionResult>(OperationResult.ProcessingResult);

                return _fdr;
            }
        }
    }
}