using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WeatherFetchFunction
{
    public class WeatherLogsGetByTimePeriod
    {
        #region Public methods
        [FunctionName(nameof(WeatherLogsGetByTimePeriod))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "logs")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation(Properties.Resources.WeatherFetchRequestByTimePeriod_Start);

            if (!req.Query.TryGetValue(Properties.Resources.WeatherFetchRequestParameter_From, out var from))
            {
                return BadRequestErrorMessageResult(Properties.Resources.WeatherFetchError_MissingFromParameter, log);
            }
            if (!req.Query.TryGetValue(Properties.Resources.WeatherFetchRequestParameter_To, out var to))
            {
                return BadRequestErrorMessageResult(Properties.Resources.WeatherFetchError_MissingToParameter, log);
            }
            if (!DateTime.TryParse(from, out DateTime fromDateTime))
            {
                return BadRequestErrorMessageResult(Properties.Resources.WeatherFetchError_InvalidFromParameter, log);
            }
            if (!DateTime.TryParse(to, out DateTime toDateTime))
            {
                return BadRequestErrorMessageResult(Properties.Resources.WeatherFetchError_InvalidToParameter, log);
            }

            try
            {
                var storageAccount = StorageHelper.SetupStorageAccount();
                var tableClient = storageAccount.CreateCloudTableClient();
                var table = tableClient.GetTableReference(Properties.Resources.WeatherFetchLogsTable);
                var columnName = Properties.Resources.WeatherFetchStorageTimestampColumnName;

                var query = new TableQuery<WeatherFetchLogEntity>().
                    Where(TableQuery.CombineFilters(
                        TableQuery.GenerateFilterConditionForDate(columnName, QueryComparisons.GreaterThanOrEqual, fromDateTime),
                        TableOperators.And,
                        TableQuery.GenerateFilterConditionForDate(columnName, QueryComparisons.LessThanOrEqual, toDateTime)));

                var logs = await table.ExecuteQuerySegmentedAsync(query, null);

                return new OkObjectResult(logs.Results);
            }
            catch (Exception ex)
            {
                log.LogError(Properties.Resources.WeatherFetchError_Default, ex.Message);
                return new InternalServerErrorResult();
            }
        }
        #endregion

        #region Private methods
        private IActionResult BadRequestErrorMessageResult(string message, ILogger logger)
        {
            logger.LogError(message);
            return new BadRequestErrorMessageResult(message);
        }
        #endregion
    }
}
