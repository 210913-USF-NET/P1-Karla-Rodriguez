using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? ProductsId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Products { get; set; }
        public virtual VendorBranch Vendor { get; set; }
    }
}
