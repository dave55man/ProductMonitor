using System.Collections.Generic;
using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.Model.Service.Contracts
{
    public interface IVendorService
    {
        /// <summary>
        /// Returns a list of all the vendors
        /// </summary>
        /// <returns></returns>
        IEnumerable<Vendor> GetListOfVendors();
    }
}
