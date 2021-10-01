using System;
using System.Collections.Generic;


namespace Models
{
    public class Products
    {
        public Products() {}

        public Products(string name, decimal price, string description, int productId)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.ProductId = productId;
        }
        public string Name {get; set;}

        public decimal Price {get; set;}
        public string Description {get; set;}

        public int ProductId {get; set;}

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