using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.DataAccess.Contracts
{
    public interface IVendorDao
    {
        /// <summary>
        /// Returns a list of vendors from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Vendor> GetVendors();

        /// <summary>
        /// Retrieves the updated Vendor Product from the database
        /// </summary>
        /// <param name="update"></param>
        /// <returns>Will return null if the product is not found</returns>
        VendorProduct GetUpdatedVendorProduct(ProductUpdate update);
    }
}
