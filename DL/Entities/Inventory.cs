using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Inventory
    {
        public int? ProductId { get; set; }
        public int? VendorId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual VendorBranch Vendor { get; set; }
    }
}
