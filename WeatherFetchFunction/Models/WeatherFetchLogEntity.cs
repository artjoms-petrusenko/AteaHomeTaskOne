using Microsoft.WindowsAzure.Storage.Table;

namespace WeatherFetchFunction
{
    public class WeatherFetchLogEntity : TableEntity
    {
        public int? StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
