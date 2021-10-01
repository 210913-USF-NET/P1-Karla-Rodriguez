using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Models
{
    public class Orders
    {    
        [Key]
        public int OrderId {get; set;}

        public int CustomerId{get; set;}

        public int VendorId{get; set;}

        public int ProductId { get; set; }

        public List<Products> Products {get;set;}
        public List<LineItem> LineItems {get; set;}

        public decimal Totals {get; set;}

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Thank you for your purchase!";
        }
    }
}