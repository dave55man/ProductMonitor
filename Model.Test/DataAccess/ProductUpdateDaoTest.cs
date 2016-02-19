using Microsoft.WindowsAzure.Storage.Queue;
using NUnit.Framework;
using System.Threading;
using Trek.ProductMonitor.Model.DataAccess;
using Trek.ProductMonitor.Model.DataAccess.Contracts;

namespace Model.Test.DataAccess
{
    [TestFixture]
    public class ProductUpdateDaoTest
    {
        private readonly IProductUpdateDao _testDao = new ProductUpdateDao();

        [Test]
        public void GetMessageTest()
        {
            var message = TryToGetMessage();

            Assert.That(message, Is.Not.Null);
            Assert.That(message.AsString.Contains("Updates"));
        }

        [Test]
        public void DeleteMessageTest()
        {
            var message = TryToGetMessage();

            Assert.That(message, Is.Not.Null);
            Assert.DoesNotThrow(() => _testDao.DeleteMessage(message));
        }

        private CloudQueueMessage TryToGetMessage()
        {
            CloudQueueMessage message = null;

            //May have to try a couple times for a message to appear
            int retryCount = 0;
            while (retryCount < 10 && message == null)
            {
                retryCount++;
                Assert.DoesNotThrow(() => message = _testDao.GetMessage());
                if(message == null) Thread.Sleep(1000); //Sleep for a tiny bit so we don't hammer the server
            }

            return message;
        }
    }
}
