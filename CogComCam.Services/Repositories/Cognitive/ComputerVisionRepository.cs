using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CogComCam.DataContracts.Configuration.Cognitive;

namespace CogComCam.Services.Repositories.Cognitive
{
    public class ComputerVisionRepository : IComputerVisionRepository
    {
        private readonly ComputerVisionConfiguration _computerVisionConfiguration;

        public ComputerVisionRepository(ComputerVisionConfiguration computerVisionConfiguration)
        {
            _computerVisionConfiguration = computerVisionConfiguration;
        }

        public async Task<object> DetectObjects(Stream imageStream)
        {
            var imagesBytes = new byte[imageStream.Length];
            imageStream.Read(imagesBytes, 0, (int) imageStream.Length);
            return await DetectObjects(imagesBytes);
        }

        public async Task<object> DetectObjects(byte[] imageBytes)
        {
            // Reference https://docs.microsoft.com/en-us/azure/cognitive-services/emotion/quickstarts/csharp
            using(var client = new HttpClient())
            {
                // Request headers - replace this example key with your valid subscription key.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _computerVisionConfiguration.Key);

                // Request parameters. A third optional parameter is "details".
                var requestParameters = "visualFeatures=Categories,Tags,Description,Faces&language=en";
                var uri = _computerVisionConfiguration.BaseApiUri + "/analyze?" + requestParameters;

                HttpResponseMessage response;

                using(var content = new ByteArrayContent(imageBytes))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json" and "multipart/form-data".
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response = await client.PostAsync(uri, content);

                }

                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }
        }
    }
}