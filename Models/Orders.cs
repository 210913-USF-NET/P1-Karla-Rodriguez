using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Models
{
    public class Orders
    {
        public Orders()
        {
        }

        public Orders(int custId, int veId) 
        {
            this.CustomersId = custId;
            this.VendorBranchesId = veId;
            this.DateandTime = DateTime.Now;
            

        }

        
        public int Id {get; set;}

        public int CustomersId{get; set;}
        public int VendorBranchesId{get; set;}

        public int ProductsId { get; set; }
        
        public int Quantity { get; set; }

      public List<LineItem> LineItems { get; set; }

        

        public DateTime DateandTime { get; set; }
        

        public override string ToString()
        {
            return $"Thank you for your purchase!";
        }
    }
}