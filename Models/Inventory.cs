using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{
public class Inventory
{
    
    [Key]
    public int InventoryId { get; set; }
    public int ProductId {get; set;} 

    public Products Name { get; set; }

    public int VendorId {get; set;}
    public int Quantity {get; set;}

    public override string ToString()
    {
    return $"Vendor Id: {this.VendorId} \n Quantity: {this.Quantity}"; 
        
    }
}
}
