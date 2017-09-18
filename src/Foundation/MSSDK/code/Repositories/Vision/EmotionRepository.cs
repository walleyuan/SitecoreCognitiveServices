using System.Linq;
using System.IO;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using Newtonsoft.Json;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Vision
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

            var response = RepositoryClient.SendJsonPost(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognize{qs}", JsonConvert.SerializeObject(new Asset { Url = imageUrl }));

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

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognize{qs}", JsonConvert.SerializeObject(new Asset { Url = imageUrl }));

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual Emotion[] Recognize(Stream imageStream) {
            return Recognize(imageStream, null);
        }

        public virtual Emotion[] Recognize(Stream imageStream, Rectangle[] faceRectangles) {

            var qs = GetRectangleQS(faceRectangles);

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognize{qs}", imageStream);

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual async Task<Emotion[]> RecognizeAsync(Stream imageStream) {
            return await RecognizeAsync(imageStream, null);
        }

        public virtual async Task<Emotion[]> RecognizeAsync(Stream imageStream, Rectangle[] faceRectangles) {

            var qs = GetRectangleQS(faceRectangles);

            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognize{qs}", imageStream);

            return JsonConvert.DeserializeObject<Emotion[]>(response);
        }

        public virtual VideoOperation RecognizeInVideo(Stream videoStream, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", videoStream);

            return JsonConvert.DeserializeObject<VideoOperation>(response);
        }

        public virtual async Task<VideoOperation> RecognizeInVideoAsync(Stream videoStream, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {
            
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", videoStream);

            return JsonConvert.DeserializeObject<VideoOperation>(response);
        }

        public virtual VideoOperation RecognizeInVideo(byte[] videoBytes, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            using (MemoryStream memoryStream = new MemoryStream(videoBytes)) {

                var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", memoryStream);

                return JsonConvert.DeserializeObject<VideoOperation>(response);
            }
        }

        public virtual async Task<VideoOperation> RecognizeInVideoAsync(byte[] videoBytes, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            using (MemoryStream memoryStream = new MemoryStream(videoBytes)) {

                var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", memoryStream);

                return JsonConvert.DeserializeObject<VideoOperation>(response);
            }
        }

        public virtual VideoOperation RecognizeInVideo(string videoUrl, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", JsonConvert.SerializeObject(new Asset { Url = videoUrl }));

            return JsonConvert.DeserializeObject<VideoOperation>(response);
        }

        public virtual async Task<VideoOperation> RecognizeInVideoAsync(string videoUrl, VideoOutputStyleOptions outputStyle = VideoOutputStyleOptions.Aggregate) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Emotion, $"{ApiKeys.EmotionEndpoint}recognizeInVideo?outputStyle{outputStyle}", JsonConvert.SerializeObject(new Asset { Url = videoUrl }));

            return JsonConvert.DeserializeObject<VideoOperation>(response);
        }

        public virtual VideoOperationResult GetOperationResult(VideoOperation operation) {

            var response = RepositoryClient.SendGet(ApiKeys.Emotion, operation.Url);

            return JsonConvert.DeserializeObject<VideoOperationResult>(response);
        }

        public virtual async Task<VideoOperationResult> GetOperationResultAsync(VideoOperation operation) {
            
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Emotion, operation.Url);

            return JsonConvert.DeserializeObject<VideoOperationResult>(response);
        }
    }
}
