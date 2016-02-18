using System.Collections.Generic;
using System.Linq;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.DataAccess
{
    public class VendorDao : IVendorDao
    {
        /// <summary>
        /// Returns a list of vendors from Azure
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendorProduct> GetVendorProductsByKeys(string vendorCode, HashSet<string> rowKeys)
        {
            return DataSources.TrekVendorData.CreateQuery<VendorProduct>().Where(VendorProduct => VendorProduct.PartitionKey == vendorCode
                && rowKeys.Contains(VendorProduct.RowKey));
        }

        /// <summary>
        /// Returns a list of Vendor Products given their IDs
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<Vendor> GetVendors()
        {
            return DataSources.TrekVendorData.CreateQuery<Vendor>().Where(Vendor => Vendor.PartitionKey == Codes.Strings.Vendor);
        }
    }
}
