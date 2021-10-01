using System;
using System.Collections.Generic;
using System.Linq;


namespace Models
{
    public class Orders
    {    
        
        // reference to ID orders
        public Orders(){}
        public Orders(int OrderId, int CustomerId, int ProductId, int VendorId)
        {
            this.OrderId = OrderId;
            this.CustomerId = CustomerId;
            this.VendorId = VendorId;
            this.ProductId = ProductId;
        }

        public int OrderId {get; set;}

        public int CustomerId{get; set;}

        public int VendorId{get; set;}

        public int ProductId {get;set;}
        public List<LineItem> LineItems {get; set;}

        public decimal Totals {get; set;}

        public override string ToString()
        {
            return $"Thank you for your purchase!";
        }
    }
}