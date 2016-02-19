using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace Trek.ProductMonitor.Model.DataAccess
{
    public static class DataSources
    {
        private static CloudStorageAccount _storageAccount
        {
            get { return CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]); }
        }

        public static CloudTable VendorData
        {
            get
            {
                return _storageAccount.CreateCloudTableClient().GetTableReference("VendorData");
            }
        }

        public static CloudQueue ProductUpdates
        {
            get
            {
                return _storageAccount.CreateCloudQueueClient().GetQueueReference("productupdates");
            }
        }
    }
}
