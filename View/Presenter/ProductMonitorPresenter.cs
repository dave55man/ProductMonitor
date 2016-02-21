using System;
using System.Windows.Forms;
using Trek.ProductMonitor.Model.Service.Contracts;
using Trek.ProductMonitor.View.Contracts;
using Trek.ProductMonitor.View.Model;

namespace Trek.ProductMonitor.View.Presenter
{
    public class ProductMonitorPresenter : IDisposable
    {
        private readonly IProductMonitor _view;
        private readonly IVendorService _vendorService;
        private readonly IProductUpdateService _productUpdateService;

        private Timer _timer;

        public ProductMonitorPresenter(IProductMonitor view, IVendorService vendorService, IProductUpdateService productUpdateService)
        {
            _view = view;
            _vendorService = vendorService;
            _productUpdateService = productUpdateService;

            Initialize();
        }

        private void Initialize()
        {
            //Setup the view
            _view.VendorSelectedEvent += SelectVendor;
            _view.ClearEvent += ClearProductUpdates;
            _view.ExitEvent += Exit;
            _view.SetVendors(_vendorService.GetListOfVendors());
        }

        /// <summary>
        /// Sets up a new product update timer when a new vendor is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectVendor(object sender, EventArgs e)
        {
            //Stop and dispose of the previous timer if it exists
            if(_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }

            //Then clear all of the product updates
            _view.ClearProductUpdates();

            //And finally create a new product update timer!
            _timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };

            _timer.Tick += GetProductUpdates;
            _timer.Start();
        }

        /// <summary>
        /// Clears all of the Product Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearProductUpdates(object sender, EventArgs e)
        {
            _view.ClearProductUpdates();
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, EventArgs e)
        {
            Program.Exit();
        }

        /// <summary>
        /// Grabs the latest product udpates for the selected vendor and shows them to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void GetProductUpdates(object sender, EventArgs e)
        {
            var currentVendor = _view.SelectedVendor;
            var updates = _productUpdateService.GetLatestProductUpdatesForVendor(currentVendor.Code);
            foreach(var update in updates)
            {
                _view.AddProductUpdate(new ProductUpdateModel(currentVendor, update));
            }
        }

        //Make sure to dispose of the timer!
        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }
    }
}
