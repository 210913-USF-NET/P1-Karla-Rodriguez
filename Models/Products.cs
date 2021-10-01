using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name {get; set;}

        public decimal Price {get; set;}
        public string Description {get; set;}

        

        public List<Inventory> Inventory {get; set;}

        public override string ToString()
        {
            //get quant
            //quant--;
            //write to database

            return $"\nName: {this.Name},\n Price: {this.Price},\n Description: {this.Description}";
        }
        
    }
}