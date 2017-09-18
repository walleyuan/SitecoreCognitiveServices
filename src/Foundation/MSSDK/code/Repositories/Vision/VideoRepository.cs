using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision
{
    public class VideoRepository : IVideoRepository
    {
        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public VideoRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }
        
        public virtual VideoOperation FaceDetectionAndTracking(string videoUrl) {
            var response = RepositoryClient.SendOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}trackface", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> FaceDetectionAndTrackingAsync(string videoUrl) {
            var response = await RepositoryClient.SendOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}trackface", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual VideoOperation FaceDetectionAndTracking(Stream videoStream) {
            var response = RepositoryClient.SendOctetOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}trackface", videoStream);

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> FaceDetectionAndTrackingAsync(Stream videoStream) {
            var response = await RepositoryClient.SendOctetOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}trackface", videoStream);

            return new VideoOperation(response);
        }

        public virtual VideoOperationResult GetOperationResult(VideoOperation operation) {
            var response = RepositoryClient.SendGet(ApiKeys.Video, operation.Url);

            return JsonConvert.DeserializeObject<VideoOperationResult>(response);
        }

        public virtual async Task<VideoOperationResult> GetOperationResultAsync(VideoOperation operation) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Video, operation.Url);

            return JsonConvert.DeserializeObject<VideoOperationResult>(response);
        }

        public virtual Stream GetResultVideo(string url) {
            var response = RepositoryClient.SendGet(ApiKeys.Video, url);

            return JsonConvert.DeserializeObject<Stream>(response);
        }

        public virtual async Task<Stream> GetResultVideoAsync(string url) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Video, url);

            return JsonConvert.DeserializeObject<Stream>(response);
        }

        public virtual string DetectMotionQS(SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold) {

            StringBuilder sb = new StringBuilder();
            sb.Append($"?sensitivityLevel={sensitivityLevel}&frameSamplingValue={frameSamplingValue}&detectLightChange={detectLightChange}&mergeTimeThreshold={mergeTimeThreshold}");

            if (detectionZones != null)
                sb.Append($"&detectionZones={string.Join("|", detectionZones.Select(z => string.Join(";", z.Points.Select(p => string.Join(",", p.X, p.Y)))))}");

            return sb.ToString();
        }

        public virtual VideoOperation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {

            var qs = DetectMotionQS(sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

            var response = RepositoryClient.SendOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}detectmotion{qs}", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        /// <param name="sensitivityLevel">Specify the detection sensitivity level: “low”, “medium”, “high”. Higher sensitivity means more motions will be detected at a cost that more false alarms will be reported. The default value is “medium”.</param>
        /// <param name="frameSamplingValue">User may skip frames by setting this parameter. It can be used as a tradeoff between performance and cost, skipping frames may reduce processing time but result in worse detection performance. The default value is 1, meaning detecting motion for every frame. If set to 2, then the algorithm will detect one frame for every two frames. The upper bound is 20.</param>
        /// <param name="detectionZones">Each detection zone is a list of points and each point is defined by a “x,y” pair. At most 8 detection zones are supported and each detection zone should be defined by at least 3 points and no more than 16 points. The default setting is “detectionZones=0,0;0.5,0;1,0;1,0.5;1,1;0.5,1;0,1;0,0.5”, i.e. the whole frame defined by an 8-point polygon.</param>
        /// <param name="detectLightChange">Specify whether light change events should be detected. The default value is false.</param>
        /// <param name="mergeTimeThreshold">Specify the threshold on whether successive motions should be merged together, if the interval between successive motions is &lt;= mergeTimeThreshold, they will be merged. The default value is 0.0 and upper bound is 10.0.</param>
        public virtual async Task<VideoOperation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1,  List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {

            var qs = DetectMotionQS(sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

            var response = await RepositoryClient.SendOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}detectmotion{qs}", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual VideoOperation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {

            var qs = DetectMotionQS(sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

            var response = RepositoryClient.SendOctetOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}detectmotion{qs}", videoStream);

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {

            var qs = DetectMotionQS(sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

            var response = await RepositoryClient.SendOctetOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}detectmotion{qs}", videoStream);

            return new VideoOperation(response);
        }

        public virtual VideoOperation Stabilization(string videoUrl) {
            var response = RepositoryClient.SendOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}stabilize", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> StabilizationAsync(string videoUrl) {
            var response = await RepositoryClient.SendOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}stabilize", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual VideoOperation Stabilization(Stream videoStream) {
            var response = RepositoryClient.SendOctetOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}stabilize", videoStream);

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> StabilizationAsync(Stream videoStream) {
            var response = await RepositoryClient.SendOctetOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}stabilize", videoStream);

            return new VideoOperation(response);
        }

        public virtual string ThumbnailQS(int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut) {
            return $"?maxMotionThumbnailDurationInSecs={maxMotionThumbnailDurationInSecs}&outputAudio={outputAudio}&fadeInFadeOut{fadeInFadeOut}";
        }

        public virtual VideoOperation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            var qs = ThumbnailQS(maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

            var response = RepositoryClient.SendOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}generatethumbnail{qs}", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            var qs = ThumbnailQS(maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

            var response = await RepositoryClient.SendOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}generatethumbnail{qs}", JsonConvert.SerializeObject(new Video { Url = videoUrl }));

            return new VideoOperation(response);
        }

        public virtual VideoOperation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            var qs = ThumbnailQS(maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

            var response = RepositoryClient.SendOctetOperationPost(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}generatethumbnail{qs}", videoStream);

            return new VideoOperation(response);
        }

        public virtual async Task<VideoOperation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            var qs = ThumbnailQS(maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

            var response = await RepositoryClient.SendOctetOperationPostAsync(ApiKeys.Video, $"{ApiKeys.VideoEndpoint}generatethumbnail{qs}", videoStream);

            return new VideoOperation(response);
        }
    }
}
