using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WeatherFetchFunction
{
    public class WeatherPayloadGetByKey
    {
        #region Public methods
        [FunctionName(nameof(WeatherPayloadGetByKey))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "payload/{logKey}")] HttpRequest req,
            string logKey,
            ILogger log)
        {
            log.LogInformation(Properties.Resources.WeatherFetchRequestByKey_Start);
            try
            {
                var connectionString = StorageHelper.GetConnectionString();
                var blobServiceClient = new BlobServiceClient(connectionString);
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(Properties.Resources.WeatherFetchPayloadsBlob);
                var blobClient = blobContainerClient.GetBlobClient($"{logKey}.{Properties.Resources.WeatherFetchBlobType}");

                if(await blobClient.ExistsAsync())
                {
                    var blobContent = default(string);
                    using(var memoryStream = new MemoryStream())
                    {
                        await blobClient.DownloadToAsync(memoryStream);
                        blobContent = Encoding.UTF8.GetString(memoryStream.ToArray());
                    }

                    log.LogInformation(Properties.Resources.WeatherFetchRequestByKey_Success);
                    return new OkObjectResult(blobContent);
                }
                else
                {
                    log.LogError(Properties.Resources.WeatherFetchError_NotFound);
                    return new NotFoundResult();
                }
            }
            catch(Exception ex)
            {
                log.LogError(Properties.Resources.WeatherFetchError_Default, ex.Message);
                return new InternalServerErrorResult();
            }
        }
        #endregion
    }
}
