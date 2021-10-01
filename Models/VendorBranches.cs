using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VendorBranches
    {
        [Key]
        public int VendorId {get; set;}
        public string Name {get; set;}

        public string GrandCompany { get; set; }
        public string CityState {get; set;} 

        

        public override string ToString()
        {
            return $"Id: {this.VendorId}, Name:{this.Name} , CityState: {this.CityState}";
        }

        public List<Inventory> Inventories { get; set; }
    }
}