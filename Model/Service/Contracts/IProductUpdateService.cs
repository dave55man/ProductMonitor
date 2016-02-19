using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.Service.Contracts
{
    public interface IProductUpdateService
    {
        /// <summary>
        /// Grabs the latest product updates for the given vendor
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns>Will return an empty list if nothing has been updated</returns>
        IEnumerable<VendorProduct> GetLatestProductUpdatesForVendor(string vendorCode);
    }
}
