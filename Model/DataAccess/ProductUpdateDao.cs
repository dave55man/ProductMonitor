using Microsoft.WindowsAzure.Storage.Queue;
using Trek.ProductMonitor.Model.DataAccess.Contracts;

namespace Trek.ProductMonitor.Model.DataAccess
{
    public class ProductUpdateDao : IProductUpdateDao
    {
        /// <summary>
        /// Deletes the given message from the queue
        /// </summary>
        /// <param name="message"></param>
        public void DeleteMessage(CloudQueueMessage message)
        {
            DataSources.ProductUpdates.DeleteMessage(message);
        }

        /// <summary>
        /// Get's the next message in the queue
        /// </summary>
        /// <returns></returns>
        public CloudQueueMessage GetMessage()
        {
            return DataSources.ProductUpdates.GetMessage();
        }
    }
}
