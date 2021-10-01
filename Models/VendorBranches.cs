using System;
using System.Collections.Generic;

namespace Models
{
    public class VendorBranches
    {
        public VendorBranches() 
        {
            this.VendorId = VendorId;
            this.Name = Name;
            this.CityState = CityState;

        }
        
        public int VendorId {get; set;}
        public string Name {get; set;}

        public string CityState {get; set;} 

        public List<Inventory> Inventories {get; set;}

        public override string ToString()
        {
            return $"Id: {this.VendorId}, Name:{this.Name} , CityState: {this.CityState}";
        }
    }
}