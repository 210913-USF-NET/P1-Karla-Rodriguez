using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Serilog;

namespace Models
{
public class Inventory
{
        private Inventory inventory;

        public Inventory() {
            Log.Debug("Database connection");
            this.Orders = new List<Orders>();
        }

        public Inventory(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public Inventory (int prId, int vId, int Quan)
        {
            this.ProductsId = prId;
            this.VendorBranchesId = vId;
            this.Quantity = Quan;
        }



    public List<Orders> Orders {get; set;}
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
