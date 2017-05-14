using System;
using System.IO;
using System.Threading.Tasks;
using CogComCam.DataContracts.Configuration.Cognitive;
using CogComCam.Services.Repositories.Cognitive;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CogComCam.Services.IntegrationTests.Repositories.Cognitive
{
    public class ComputerVisionRepositoryIntegrationTests
    {
        [TestClass]
        public class DetectObjectsAsyncIntegrationTests
        {
            [TestMethod]
            public async Task DetectsObjectsInImage()
            {
                // Arrange
                var computerVisionConfiguration = new ComputerVisionConfiguration
                {
                    BaseApiUri = "https://eastus2.api.cognitive.microsoft.com/vision/v1.0",
                    Key = "<insertkey>"
                };
                var computerVisionRepository = new ComputerVisionRepository(computerVisionConfiguration);

                var resourcePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory
                                                    + "\\..\\..\\..\\Resources\\PhotoSamples\\002.jpg");

                var image = File.ReadAllBytes(resourcePath);

                // Act
                var result = await computerVisionRepository.DetectObjects(image);

                // Assert
                Assert.IsNotNull(result);
            }
        }
    }
}