using Microsoft.WindowsAzure.Storage.Queue;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.Model.Service;

namespace Model.Test.Service
{
    [TestFixture]
    public class ProductUpdateServiceTest
    {
        private readonly IVendorDao _vendorMoq = MockRepository.GenerateMock<IVendorDao>();
        private readonly IProductUpdateDao _productUpdateMoq = MockRepository.GenerateMock<IProductUpdateDao>();

        [Test]
        public void GetLatestProductUpdatesForVendorTestSingleUpdate()
        {
            var moqProduct = MockRepository.GenerateStub<VendorProduct>();

            _productUpdateMoq.Stub(x => x.GetMessage()).Return(new CloudQueueMessage("{Updates:[{VendorCode:\"TRK\", ProductId: \"Test\"},{VendorCode:\"TTT\", ProductId: \"Test2\"}]}")).Repeat.Once();
            _vendorMoq.Stub(x => x.GetUpdatedVendorProduct(Arg<ProductUpdate>.Matches(pu => pu.VendorCode == "TRK" && pu.ProductId == "Test"))).Return(moqProduct).Repeat.Once();

            IEnumerable<VendorProduct> results = null;
            var testService = new ProductUpdateService(_vendorMoq, _productUpdateMoq);
            Assert.DoesNotThrow(() => results = testService.GetLatestProductUpdatesForVendor("TRK"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(results.First(), Is.EqualTo(moqProduct));
        }

        [Test]
        public void GetLatestProductUpdatesForVendorTestMultipleUpdates()
        {
            var moqProduct1 = MockRepository.GenerateStub<VendorProduct>();
            var moqProduct2 = MockRepository.GenerateStub<VendorProduct>();

            _productUpdateMoq.Stub(x => x.GetMessage()).Return(new CloudQueueMessage("{Updates:[{VendorCode:\"TRK\", ProductId: \"Test1\"},{VendorCode:\"TRK\", ProductId: \"Test2\"}]}")).Repeat.Once();
            _vendorMoq.Stub(x => x.GetUpdatedVendorProduct(Arg<ProductUpdate>.Matches(pu => pu.VendorCode == "TRK" && pu.ProductId == "Test1"))).Return(moqProduct1).Repeat.Once();
            _vendorMoq.Stub(x => x.GetUpdatedVendorProduct(Arg<ProductUpdate>.Matches(pu => pu.VendorCode == "TRK" && pu.ProductId == "Test2"))).Return(moqProduct2).Repeat.Once();

            IEnumerable<VendorProduct> results = null;
            var testService = new ProductUpdateService(_vendorMoq, _productUpdateMoq);
            Assert.DoesNotThrow(() => results = testService.GetLatestProductUpdatesForVendor("TRK"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count(), Is.EqualTo(2));
            Assert.That(results.Contains(moqProduct1));
            Assert.That(results.Contains(moqProduct2));
        }

        [Test]
        public void GetLatestProductUpdatesForVendorTestNoUpdates()
        {
            _productUpdateMoq.Stub(x => x.GetMessage()).Return(null).Repeat.Once();

            IEnumerable<VendorProduct> results = null;
            var testService = new ProductUpdateService(_vendorMoq, _productUpdateMoq);
            Assert.DoesNotThrow(() => results = testService.GetLatestProductUpdatesForVendor("TRK"));
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count(), Is.EqualTo(0));
        }
    }
}
