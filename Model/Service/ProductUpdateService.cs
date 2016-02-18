using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.Model.Service.Contracts;

namespace Trek.ProductMonitor.Model.Service
{
    public class ProductUpdateService : IProductUpdateService
    {
        /// <summary>
        /// Returns a list of all the updated vendor products
        /// </summary>
        /// <returns>Will return an empty list if nothing has been updated</returns>
        public IEnumerable<VendorProduct> GetUpdatedVendorProducts()
        {
            throw new NotImplementedException();
        }
    }
}
