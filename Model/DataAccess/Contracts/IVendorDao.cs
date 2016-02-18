using System;
using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.DataAccess.Contracts
{
    public interface IVendorDao
    {
        /// <summary>
        /// Returns a list of vendors from Azure
        /// </summary>
        /// <returns></returns>
        IEnumerable<Vendor> GetVendors();

        /// <summary>
        /// Returns a list of Vendor Products given their IDs
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <param name="rowKeys"></param>
        /// <returns></returns>
        IEnumerable<VendorProduct> GetVendorProductsByKeys(string vendorCode, HashSet<string> rowKeys);
    }
}
