using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace Trek.ProductMonitor.Model.DataAccess
{
    public static class DataSources
    {
        public static CloudTable TrekVendorData
        {
            get
            {
                var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                var client = storageAccount.CreateCloudTableClient();
                return client.GetTableReference("VendorData");
            }
        }
    }
}
