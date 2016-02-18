using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.Service.Contracts
{
    public interface IProductUpdateService
    {
        /// <summary>
        /// Returns a list of all the updated vendor products
        /// </summary>
        /// <returns>Will return an empty list if nothing has been updated</returns>
        IEnumerable<VendorProduct> GetUpdatedVendorProducts();
    }
}
