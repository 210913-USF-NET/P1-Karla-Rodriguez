using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{
public class Inventory
{
    
        public Inventory() { }

        public Inventory (int prId, int vId, int Quan)
        {
            this.ProductId = prId;
            this.VendorId = vId;
            this.Quantity = Quan;
        }


        public Inventory(string product, int Quan)
        {
            this.Product = product;
            this.Quantity = Quan;
        }

    
    public int Id { get; set; }
    public int ProductId {get; set;} 

    public string Product { get; set; }

    public int VendorId {get; set;}
    public int Quantity {get; set;}

    public override string ToString()
    {
    return $"Purchase: {this.Product} , Product: {this.ProductId} , \nVendor Id: {this.VendorId} \n Quantity: {this.Quantity}"; 
        
    }
}
}
