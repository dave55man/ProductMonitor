using System.Collections.Generic;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.Model.Service.Contracts;

namespace Trek.ProductMonitor.Model.Service
{
    public class VendorService : IVendorService
    {
        private readonly IVendorDao _vendorDao;

        public VendorService(IVendorDao vendorDao)
        {
            _vendorDao = vendorDao;
        }

        /// <summary>
        /// Returns a list of all the vendors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> GetListOfVendors()
        {
            return _vendorDao.GetVendors();
        }
    }
}
