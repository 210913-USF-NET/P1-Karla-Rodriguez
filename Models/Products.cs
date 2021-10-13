using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Products
    {
        public Products()
        {
        }

        public Products(string name)
        {
            this.Name = name;
        }

        public Products(string name, decimal Price, string Description) : this(name)
        {
            this.Price = Price;
            this.Description = Description;
        }


        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }



        public int InventoryId { get; set; }

        public override string ToString()
        {
            //get quant
            //quant--;
            //write to database

            return $"\nName: {this.Name},\n Price: {this.Price},\n Description: {this.Description}";
        }

    }
}