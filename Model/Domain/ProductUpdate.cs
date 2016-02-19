namespace Trek.ProductMonitor.Model.Domain
{
    public class ProductUpdate
    {
        public string VendorCode { get; set; }
        public string ProductId { get; set; }

        public string ProductRowKey
        {
            get
            {
                return string.Format("Product__{0}", ProductId);
            }
        }
    }
}
