using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.Model.Service.Contracts;
using Trek.ProductMonitor.View.Contracts;
using Trek.ProductMonitor.View.Model;
using Trek.ProductMonitor.View.Presenter;

namespace View.Test.Presenter
{
    [TestFixture]
    public class ProductMasterPresenterTest
    {
        private readonly IProductUpdateService _moqProductUpdateService = MockRepository.GenerateMock<IProductUpdateService>();
        private readonly IVendorService _moqVendorService = MockRepository.GenerateMock<IVendorService>();
        private IProductMaster _moqProductMaster;
        private ProductMasterPresenter _testPresenter;

        private readonly Vendor _stubVendor = MockRepository.GenerateStub<Vendor>();

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _stubVendor.Name = "Trek";
            _stubVendor.Code = "TRK";

            _moqVendorService.Stub(x => x.GetListOfVendors()).Return(new List<Vendor> { _stubVendor }).Repeat.Any();
        }

        [SetUp]
        public void PreTest()
        {
            _moqProductMaster = MockRepository.GenerateMock<IProductMaster>();
            _moqProductMaster.Stub(x => x.SelectedVendor).Return(_stubVendor).Repeat.Any();

            _testPresenter = new ProductMasterPresenter(_moqProductMaster, _moqVendorService, _moqProductUpdateService);
        }

        [TearDown]
        public void PostTest()
        {
            _testPresenter.Dispose();
        }

        [Test]
        public void SelectVendorTest()
        {
            //Raise the Vendor Selected Event
            _moqProductMaster.Raise(r => r.VendorSelectedEvent += null, _moqProductMaster, EventArgs.Empty);

            //Make sure the list was cleared...
            _moqProductMaster.AssertWasCalled(x => x.ClearProductUpdates(), options => options.Repeat.Once());
        }

        [Test]
        public void ClearButtonTest()
        {
            //Raise the Vendor Selected Event
            _moqProductMaster.Raise(r => r.ClearEvent += null, _moqProductMaster, EventArgs.Empty);

            //Make sure the list was cleared...
            _moqProductMaster.AssertWasCalled(x => x.ClearProductUpdates(), options => options.Repeat.Once());
        }

        [Test]
        public void GetProductUpdatesTest()
        {
            var testProduct = MockRepository.GenerateStub<VendorProduct>();
            testProduct.Name = "Test";
            testProduct.Price = 3.50m;
            testProduct.Description = "Test Test";
            _moqProductUpdateService.Stub(x => x.GetLatestProductUpdatesForVendor(_stubVendor.Code)).Return(new List<VendorProduct> { testProduct }).Repeat.Twice();

            //Call the method two times (to simluate 2 updates)
            _testPresenter.GetProductUpdates(null, EventArgs.Empty);
            _testPresenter.GetProductUpdates(null, EventArgs.Empty);

            //Assert that everything was updated correctly!
            _moqProductUpdateService.AssertWasCalled(x => x.GetLatestProductUpdatesForVendor(_stubVendor.Code), options => options.Repeat.Twice());
            _moqProductMaster.AssertWasCalled(x => x.AddProductUpdate(Arg<ProductUpdateModel>.Matches(pu =>
                pu.Name == "Test" &&
                pu.Price == "$3.50" &&
                pu.Description == "Test Test" &&
                pu.Vendor == _stubVendor.Name)), options => options.Repeat.Twice());
        }
    }
}
