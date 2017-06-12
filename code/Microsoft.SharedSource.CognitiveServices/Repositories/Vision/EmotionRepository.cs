using System.Linq;
using Microsoft.ProjectOxford.Common;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public class EmotionRepository : IEmotionRepository
    {
        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;
        
        public EmotionRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual string GetRectangleQS(Rectangle[] rectangles) {
            return (rectangles == null) ? "" : $"?faceRectangles={string.Join(";", rectangles.Select(r => $"{r.Left},{r.Top},{r.Width},{r.Height}"))}";
        }

        public virtual Emotion[] Recognize(string imageUrl, Rectangle[] faceRectangles) {

            var qs = GetRectangleQS(faceRectangles);

            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognize{qs}", JsonConvert.SerializeObject(new Asset { Url = imageUrl }));

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual Emotion[] Recognize(string imageUrl) {
            return Recognize(imageUrl, null);
        }

        public virtual async Task<Emotion[]> RecognizeAsync(string imageUrl) {
            return await RecognizeAsync(imageUrl, null);
        }
        
        public virtual async Task<Emotion[]> RecognizeAsync(string imageUrl, Rectangle[] faceRectangles) {

            var qs = GetRectangleQS(faceRectangles);

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognize{qs}", JsonConvert.SerializeObject(new Asset { Url = imageUrl }));

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual Emotion[] Recognize(Stream imageStream) {
            return Recognize(imageStream, null);
        }

        public virtual Emotion[] Recognize(Stream imageStream, Rectangle[] faceRectangles) {

            var qs = GetRectangleQS(faceRectangles);

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognize{qs}", imageStream);

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual async Task<Emotion[]> RecognizeAsync(Stream imageStream) {
            return await RecognizeAsync(imageStream, null);
        }

        public virtual async Task<Emotion[]> RecognizeAsync(Stream imageStream, Rectangle[] faceRectangles) {

            var qs = GetRectangleQS(faceRectangles);

            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognize{qs}", imageStream);

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual VideoEmotionRecognitionOperation RecognizeInVideo(Stream videoStream, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", videoStream);

            return JsonConvert.DeserializeObject<VideoEmotionRecognitionOperation>(response);
        }

        public virtual async Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(Stream videoStream, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {
            
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", videoStream);

            return JsonConvert.DeserializeObject<VideoEmotionRecognitionOperation>(response);
        }

        public virtual VideoEmotionRecognitionOperation RecognizeInVideo(byte[] videoBytes, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            using (MemoryStream memoryStream = new MemoryStream(videoBytes)) {

                var response = RepositoryClient.SendOctetStreamPost(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", memoryStream);

                return JsonConvert.DeserializeObject<VideoEmotionRecognitionOperation>(response);
            }
        }

        public virtual async Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(byte[] videoBytes, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            using (MemoryStream memoryStream = new MemoryStream(videoBytes)) {

                var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", memoryStream);

                return JsonConvert.DeserializeObject<VideoEmotionRecognitionOperation>(response);
            }
        }

        public virtual VideoEmotionRecognitionOperation RecognizeInVideo(string videoUrl, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", JsonConvert.SerializeObject(new Asset { Url = videoUrl }));

            return JsonConvert.DeserializeObject<VideoEmotionRecognitionOperation>(response);
        }

        public virtual async Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(string videoUrl, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", JsonConvert.SerializeObject(new Asset { Url = videoUrl }));

            return JsonConvert.DeserializeObject<VideoEmotionRecognitionOperation>(response);
        }

        public virtual VideoOperationResult GetOperationResult(VideoEmotionRecognitionOperation operation) {

            var response = RepositoryClient.SendGet(ApiKeys.ContentModerator, operation.Url);

            return JsonConvert.DeserializeObject<VideoOperationResult>(response);
        }

        public virtual async Task<VideoOperationResult> GetOperationResultAsync(VideoEmotionRecognitionOperation operation) {
            
            var response = await RepositoryClient.SendGetAsync(ApiKeys.ContentModerator, operation.Url);

            return JsonConvert.DeserializeObject<VideoOperationResult>(response);
        }
    }
}
