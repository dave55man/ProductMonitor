using Microsoft.WindowsAzure.Storage.Table;

namespace Trek.ProductMonitor.Model.Domain
{
    public class Vendor : TableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) - {2}", Name, Code, Description);
        }
    }
}
