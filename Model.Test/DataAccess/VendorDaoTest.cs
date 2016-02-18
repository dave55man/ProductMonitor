using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Trek.ProductMonitor.Model.DataAccess;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.Domain;

namespace Model.Test.DataAccess
{
    [TestFixture]
    public class VendorDaoTest
    {
        private readonly IVendorDao _testDao = new VendorDao();

        [Test]
        public void GetVendorsTest()
        {
            IEnumerable<Vendor> results = null;
            Assert.DoesNotThrow(() => results = _testDao.GetVendors());
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.Not.Empty);

            //Assert Trek exists
            Assert.That(results.Any(r => r.Code == "TRK" && r.Name == "Trek"));
        }

        [Test]
        public void ValidGetVendorProductsTest()
        {
            var testKeys = new HashSet<string> { "Product_Test", "Product_Test2" };

            IEnumerable<VendorProduct> results = null;
            Assert.DoesNotThrow(() => results = _testDao.GetVendorProductsByKeys("TRK", testKeys));
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.Not.Empty);

            //Assert some basic information (once we find out stuff)
        }

        [Test]
        public void InvalidGetVendorProductsTest()
        {
            //Test out invalid keys
            var invalidKeys = new HashSet<string> { "Product_Test", "Product_Test2" };

            IEnumerable<VendorProduct> results = null;
            Assert.DoesNotThrow(() => results = _testDao.GetVendorProductsByKeys("TRK", invalidKeys));
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.Empty);

            //Test out invalid vendor code
            var validKeys = new HashSet<string> { "Product_Test" };

            results = null;
            Assert.DoesNotThrow(() => results = _testDao.GetVendorProductsByKeys("ZZZ", validKeys));
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.Empty);

            //Note: Not worried about null keys or vendor codes as this is only called internally
        }
    }
}
