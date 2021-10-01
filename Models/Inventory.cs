using System;
using System.Linq;
using System.Collections.Generic;
namespace Models
{
public class Inventory
{
    
    public Inventory() {}

    public Inventory(int productId, int vendorId, int quantity)
    {
        this.ProductId = productId;
        this.VendorId = vendorId;
        this.Quantity = quantity;
    }
    public int ProductId {get; set;} 

    public int VendorId {get; set;}
    public int Quantity {get; set;}

    public override string ToString()
    {
    return $"Vendor Id: {this.VendorId} \n Quantity: {this.Quantity}"; 
        
    }
}
}
