using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class VendorBranch
    {
        public VendorBranch()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CityState { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
