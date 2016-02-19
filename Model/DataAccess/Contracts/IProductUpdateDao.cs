using Microsoft.WindowsAzure.Storage.Queue;

namespace Trek.ProductMonitor.Model.DataAccess.Contracts
{
    public interface IProductUpdateDao
    {
        /// <summary>
        /// Get's the next message in the queue
        /// </summary>
        /// <returns></returns>
        CloudQueueMessage GetMessage();

        /// <summary>
        /// Deletes the given message from the queue
        /// </summary>
        /// <param name="message"></param>
        void DeleteMessage(CloudQueueMessage message);
    }
}
