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
            Assert.That(results.Any(r => r.Code == "TRK" && r.Name == "Trek Bicycle Corp" && r.Description == "Best bike company in the world"));
        }

        [Test]
        public void ValidGetUpdatedVendorProductTest()
        {
            var testUpdate = new ProductUpdate
            {
                VendorCode = "TRK",
                ProductId = "00002d4b-224c-49d1-8d6a-ef21ad7111e2"
            };

            VendorProduct result = null;
            Assert.DoesNotThrow(() => result = _testDao.GetUpdatedVendorProduct(testUpdate));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.VendorCode, Is.EqualTo("TRK"));
            Assert.That(result.Description, Is.EqualTo("Cool TRK product"));
        }

        [Test]
        public void InvalidGetUpdatedVendorProductTest()
        {
            //Test out an invalid product id
            var invalidProduct1 = new ProductUpdate
            {
                VendorCode = "TRK",
                ProductId = "Test"
            };
            VendorProduct result = null;
            Assert.DoesNotThrow(() => result = _testDao.GetUpdatedVendorProduct(invalidProduct1));
            Assert.That(result, Is.Null);

            //Test out an invalid vendor code
            var invalidProduct2 = new ProductUpdate
            {
                VendorCode = "ZZZ",
                ProductId = "00002d4b-224c-49d1-8d6a-ef21ad7111e2"
            };
            result = null;
            Assert.DoesNotThrow(() => result = _testDao.GetUpdatedVendorProduct(invalidProduct2));
            Assert.That(result, Is.Null);
        }
    }
}
