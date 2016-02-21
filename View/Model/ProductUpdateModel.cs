using Trek.ProductMonitor.Model.Domain;

namespace Trek.ProductMonitor.View.Model
{
    public class ProductUpdateModel
    {
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public ProductUpdateModel(Vendor vendor, VendorProduct product)
        {
            Name = product.Name;
            Vendor = vendor.Name;
            Description = product.Description;
            Price = product.Price.ToString("c");
        }
    }
}
