using System;
using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.View.Model;

namespace Trek.ProductMonitor.View.Contracts
{
    public interface IProductMaster
    {
        Vendor SelectedVendor { get; }

        event EventHandler<EventArgs> VendorSelectedEvent;
        event EventHandler<EventArgs> ClearEvent;
        event EventHandler<EventArgs> ExitEvent;

        void SetVendors(IEnumerable<Vendor> vendors);
        void AddProductUpdate(ProductUpdateModel update);
        void ClearProductUpdates();
    }
}
