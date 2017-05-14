using System;
using System.IO;
using System.Threading.Tasks;
using CogComCam.DataContracts.Cognitive;

namespace CogComCam.Services.Repositories.Cognitive
{
    public class EmotionRepository
    {
        public async Task<FaceEmotion> DetectEmotion(Stream imageStream, FaceLocation faceLocation)
        {
            // Reference https://docs.microsoft.com/en-us/azure/cognitive-services/emotion/quickstarts/csharp
            throw new NotImplementedException();
        }
    }
}