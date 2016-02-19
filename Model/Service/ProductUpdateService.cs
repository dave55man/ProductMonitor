using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.Domain;
using Trek.ProductMonitor.Model.Service.Contracts;

namespace Trek.ProductMonitor.Model.Service
{
    public class ProductUpdateService : IProductUpdateService
    {
        private readonly IVendorDao _vendorDao;
        private readonly IProductUpdateDao _productUpdateDao;

        public ProductUpdateService(IVendorDao vendorDao, IProductUpdateDao productUpdateDao)
        {
            _vendorDao = vendorDao;
            _productUpdateDao = productUpdateDao;
        }

        /// <summary>
        /// Grabs the latest product updates for the given vendor
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns>Will return an empty list if nothing has been updated</returns>
        public IEnumerable<VendorProduct> GetLatestProductUpdatesForVendor(string vendorCode)
        {
            var results = new List<VendorProduct>();

            //Try to grab a message to start, quickly return if nothing is found
            var message = _productUpdateDao.GetMessage();
            if (message == null) return results;

            //Parse the message into a list of ProductUpdates
            //Updates: [ProductUpdate, ProductUpdate, etc...]
            var messageJson = JObject.Parse(message.AsString);
            var jsonUpdates = (JArray)messageJson["Updates"];
            var updates = jsonUpdates.ToObject<List<ProductUpdate>>();

            //Grab the associated Vendor Products from the DataBase
            foreach(var update in updates.Where(u => u.VendorCode == vendorCode))
            {
                var product = _vendorDao.GetUpdatedVendorProduct(update);
                if (product != null) results.Add(product);
            }

            //Finally delete the message
            _productUpdateDao.DeleteMessage(message);

            return results;
        }
    }
}
