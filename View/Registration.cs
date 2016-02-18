using Bootstrap.StructureMap;
using StructureMap;
using Trek.ProductMonitor.Model.DataAccess.Contracts;
using Trek.ProductMonitor.Model.DataAccess;
using Trek.ProductMonitor.Model.Service.Contracts;
using Trek.ProductMonitor.Model.Service;

namespace Trek.ProductMonitor.View
{
    public class Registration : IStructureMapRegistration
    {
        /// <summary>
        /// Registers all of the Interfaces and their related Classes
        /// </summary>
        /// <param name="container"></param>
        public void Register(IContainer container)
        {
            container.Configure(_ => {
                _.For<IVendorDao>().Use<VendorDao>();
                _.For<IVendorService>().Use<VendorService>();
                _.For<IProductUpdateService>().Use<ProductUpdateService>();
            });
        }
    }
}
