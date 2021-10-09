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

        public Orders(int custId, int veId, int prId) 
        {
            this.CustomerId = custId;
            this.VendorId = veId;
            this.ProductId = prId;
        }

        
        public int Id {get; set;}

        public int CustomerId{get; set;}

        public int ProductId { get; set;}
        public int VendorId{get; set;}

        public string Customer { get; set; }
        public List<LineItem> LineItems {get; set;}

        

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Thank you for your purchase!";
        }
    }
}