using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Video;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
{
    public class VideoResult
    {
        public VideoOperation Operation { get; set; }
        public VideoOperationResult OperationResult { get; set; }

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