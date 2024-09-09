using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherFetchFunction
{
    public class WeatherFetchFunction
    {
        #region Private fields
        private readonly IConfiguration _configuration;
        #endregion

        #region Consructors
        public WeatherFetchFunction(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Public methods
        [FunctionName(nameof(WeatherFetchFunction))]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation(Properties.Resources.WeatherFetchTrigger_Start);

            string url = _configuration.GetValue<string>(Properties.Resources.WeatherFetchApiUrl);
            if (string.IsNullOrEmpty(url))
            {
                log.LogError(Properties.Resources.WeatherFetchError_Url);
                return;
            }

            string apiKey = _configuration.GetValue<string>(Properties.Resources.WeatherFetchApiKey);
            if (string.IsNullOrEmpty(apiKey))
            {
                log.LogError(Properties.Resources.WeatherFetchError_ApiKey);
                return;
            }

            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(url + apiKey);
                var payload = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    log.LogInformation(Properties.Resources.WeatherFetchStatus_Success);
                    var logEntity = await WeatherFecthLogSaveAsync(true, (int)response.StatusCode);
                    await WeatherFetchPayloadSaveAsync(logEntity, payload);
                }
                else
                {
                    throw new Exception(Properties.Resources.WeatherFetchError_Response);
                }
            }
            catch (HttpRequestException ex)
            {
                log.LogError(Properties.Resources.WeatherFetchError_Http, ex.Message);
                await WeatherFecthLogSaveAsync(false, null, ex.Message);
            }
            catch (Exception ex)
            {
                log.LogError(Properties.Resources.WeatherFetchError_Default, ex.Message);
                await WeatherFecthLogSaveAsync(false, null, ex.Message);
            }

            log.LogInformation(Properties.Resources.WeatherFetchTrigger_End);
        }
        #endregion

        #region Private methods
        private async Task<WeatherFetchLogEntity> WeatherFecthLogSaveAsync(bool isSuccessful, int? statusCode = null, string? errorMessage = null)
        {
            var storageAccount = StorageHelper.SetupStorageAccount();
            var tableClient = storageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference(Properties.Resources.WeatherFetchLogsTable);
            await table.CreateIfNotExistsAsync();

            string weatherFetchLogTypeMessage = isSuccessful ? 
                Properties.Resources.WeatherFetchLogType_Success : 
                Properties.Resources.WeatherFetchLogType_Failure;

            WeatherFetchLogEntity logEntity = new()
            {
                PartitionKey = weatherFetchLogTypeMessage,
                RowKey = Guid.NewGuid().ToString(),
                StatusCode = statusCode,
                StatusMessage = weatherFetchLogTypeMessage,
                ErrorMessage = errorMessage
            };

            var insertOperation = TableOperation.Insert(logEntity);
            await table.ExecuteAsync(insertOperation);

            return logEntity;
        }

        private async Task WeatherFetchPayloadSaveAsync(WeatherFetchLogEntity logEntity, string payload)
        {
            var storageAccount = StorageHelper.SetupStorageAccount();
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(Properties.Resources.WeatherFetchPayloadsBlob);
            await blobContainer.CreateIfNotExistsAsync();

            string blobName = $"{logEntity.RowKey}.{Properties.Resources.WeatherFetchBlobType}";
            var blockBlob = blobContainer.GetBlockBlobReference(blobName);
            await blockBlob.UploadTextAsync(payload);
        }
        #endregion
    }
}
