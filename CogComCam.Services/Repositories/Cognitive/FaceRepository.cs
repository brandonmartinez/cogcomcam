using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CogComCam.DataContracts.Cognitive;
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

        public async Task<IList<Face>> DetectFacesAsync(Stream imageStream)
        {
            // Resource: https://docs.microsoft.com/en-us/azure/cognitive-services/face/tutorials/faceapiincsharptutorial
            var detectedfaces = await _faceServiceClient.DetectAsync(imageStream, true, true);
            var faces = detectedfaces.Select(f => new Face
            {
                Id = f.FaceId,
                Location = new FaceLocation
                {
                    Top = f.FaceRectangle.Top,
                    Left = f.FaceRectangle.Left,
                    Width = f.FaceRectangle.Width,
                    Height = f.FaceRectangle.Height
                }
            });

            return faces.ToList();
        }

        public async Task<IList<Face>> DetectFacesAsync(byte[] imageBytes)
        {
            using(var ms = new MemoryStream(imageBytes))
            {
                return await DetectFacesAsync(ms);
            }
        }
    }
}