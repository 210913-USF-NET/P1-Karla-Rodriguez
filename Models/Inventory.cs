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
            this.ProductsId = prId;
            this.VendorBranchesId = vId;
            this.Quantity = Quan;
        }



    
    public int Id { get; set; }
    public int ProductsId {get; set;} 

    

    public int VendorBranchesId {get; set;}
    public int Quantity {get; set;}

    public override string ToString()
    {
    return $"Product: {this.ProductsId} , \nVendor Id: {this.VendorBranchesId} \n Quantity: {this.Quantity}"; 
        
    }
}
}
