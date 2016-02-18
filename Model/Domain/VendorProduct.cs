using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Trek.ProductMonitor.Model.Domain
{
    public class VendorProduct : TableEntity
    {
        public Guid ProductId { get; set; }
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
