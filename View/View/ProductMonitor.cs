using Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.View.Contracts;
using Trek.ProductMonitor.View.Model;
using Trek.ProductMonitor.View.Presenter;

namespace Trek.ProductMonitor.View.View
{
    public partial class ProductMonitor : Form, IProductMonitor
    {
        private BindingSource _productUpdates;
        private ProductMonitorPresenter _presenter;

        /// <summary>
        /// Get's the currently Selected Vendor
        /// </summary>
        public Vendor SelectedVendor
        {
            get { return VendorBox.SelectedItem as Vendor; }
        }

        //Public Event Handlers
        public event EventHandler<EventArgs> VendorSelectedEvent;
        public event EventHandler<EventArgs> ClearEvent;
        public event EventHandler<EventArgs> ExitEvent;

        public ProductMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up the Vendor ListBox
        /// </summary>
        /// <param name="vendors"></param>
        public void SetVendors(IEnumerable<Vendor> vendors)
        {
            VendorBox.DataSource = vendors.ToList();
            VendorBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a Product Update to the ProductUpdateGrid
        /// </summary>
        /// <param name="update"></param>
        public void AddProductUpdate(ProductUpdateModel update)
        {
            //The list of Product Updates can be no longer than 50
            if(_productUpdates.List.Count == 50)
            {
                _productUpdates.List.RemoveAt(0);
            }

            //Add to the top of the list
            _productUpdates.List.Insert(0, update);
        }

        /// <summary>
        /// Clears the Product Update Grid
        /// </summary>
        public void ClearProductUpdates()
        {
            _productUpdates.Clear();
        }

        private void ProductMonitor_Load(object sender, EventArgs e)
        {
            _productUpdates = ProductUpdateGrid.DataSource as BindingSource;

            //Resolve the Present upon load
            Bootstrapper.ContainerExtension.Register<IProductMonitor>(this);
            _presenter = Bootstrapper.ContainerExtension.Resolve<ProductMonitorPresenter>();
        }

        private void VendorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VendorSelectedEvent != null) VendorSelectedEvent(this, e);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (ClearEvent != null) ClearEvent(this, EventArgs.Empty);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (ExitEvent != null) ExitEvent(this, EventArgs.Empty);
        }
    }
}
