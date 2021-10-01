using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class LineItem
    {
        public int? OrdersId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order Orders { get; set; }
    }
}
