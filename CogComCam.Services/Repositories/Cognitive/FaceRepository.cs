using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;

namespace CogComCam.Services.Repositories.Cognitive
{
    public class FaceRepository

    {
        private readonly IFaceServiceClient _faceServiceClient;

        public FaceRepository(IFaceServiceClient faceServiceClient)
        {
            _faceServiceClient = faceServiceClient;
        }

        public async Task<IEnumerable<object>> DetectFacesAsync(Stream imageStream)
        {
            // Resource: https://docs.microsoft.com/en-us/azure/cognitive-services/face/tutorials/faceapiincsharptutorial
            var faces = await _faceServiceClient.DetectAsync(imageStream, true, true);
            var faceRects = faces.Select(face => face.FaceRectangle);
            return faceRects.ToArray();
        }

        public async Task<IEnumerable<object>> DetectFacesAsync(byte[] imageBytes)
        {
            using(var ms = new MemoryStream(imageBytes))
            {
                return await DetectFacesAsync(ms);
            }
        }
    }
}