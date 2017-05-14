using System;
using System.IO;
using System.Threading.Tasks;
using CogComCam.Services.Repositories.Cognitive;
using Microsoft.ProjectOxford.Face;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CogComCam.Services.IntegrationTests.Repositories.Cognitive
{
    public class FaceRepositoryIntegrationTests
    {
        [TestClass]
        public class DetectFacesAsyncMethod
        {
            [TestMethod]
            public async Task CanProcessImageSteam()
            {
                // Arrange
                var faceServiceClient = new FaceServiceClient("<insertkey>", "https://eastus2.api.cognitive.microsoft.com/face/v1.0");
                var faceRepository = new FaceRepository(faceServiceClient);
                var resourcePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory
                                                    + "\\..\\..\\..\\Resources\\PhotoSamples\\001.jpg");

                var image = File.ReadAllBytes(resourcePath);

                // Act
                var result = await faceRepository.DetectFacesAsync(image);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Count);
            }
        }
    }
}