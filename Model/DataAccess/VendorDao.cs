using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.DataAccess
{
    public class VendorDao : IVendorDao
    {
        /// <summary>
        /// Retrieves the updated Vendor Product from the database
        /// </summary>
        /// <param name="update"></param>
        /// <returns>Will return null if the product is not found</returns>
        public VendorProduct GetUpdatedVendorProduct(ProductUpdate update)
        {
            var operation = TableOperation.Retrieve<VendorProduct>(update.VendorCode, update.ProductRowKey);
            return DataSources.VendorData.Execute(operation).Result as VendorProduct;
        }

        /// <summary>
        /// Returns a list of vendors from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> GetVendors()
        {
            return DataSources.VendorData.CreateQuery<Vendor>().Where(v => v.PartitionKey == Codes.Strings.Vendor);
        }
    }
}
