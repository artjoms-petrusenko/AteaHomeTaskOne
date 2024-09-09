using Microsoft.WindowsAzure.Storage;
using System;

namespace WeatherFetchFunction
{
    public static class StorageHelper
    {
        public static string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable(Properties.Resources.WeatherFetchStorage);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception(Properties.Resources.WeatherFetchError_ConnectionString);
            }
            return connectionString;
        }
        public static CloudStorageAccount SetupStorageAccount()
        {
            var connectionString = StorageHelper.GetConnectionString();

            var storageAccount = CloudStorageAccount.Parse(connectionString);
            return storageAccount;
        }
    }
}
