using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.Model.Service.Contracts;

namespace Trek.ProductMonitor.Model.Service
{
    public class VendorService : IVendorService
    {
        /// <summary>
        /// Returns a list of all the vendors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> GetListOfVendors()
        {
            throw new NotImplementedException();
        }
    }
}
