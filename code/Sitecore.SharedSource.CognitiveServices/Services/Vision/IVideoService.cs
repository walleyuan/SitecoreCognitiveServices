using System.IO;
using Microsoft.ProjectOxford.Video.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IVideoService
    {
        Operation CreateOperation(Stream video, VideoOperationSettings operationSettings);
        Operation CreateOperation(byte[] video, VideoOperationSettings operationSettings);
        Operation CreateOperation(string videoUrl, VideoOperationSettings operationSettings);
        OperationResult GetOperationResult(Operation operation);
        Stream GetResultVideo(string url);
    }
}