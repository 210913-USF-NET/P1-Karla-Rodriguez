using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VendorBranches
    {
        
        public int Id {get; set;}
        public string Name {get; set;}

        public string GrandCompany { get; set; }
        public string CityState {get; set;}

        public List<Inventory> Inventory { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name:{this.Name} , CityState: {this.CityState}";
        }

       
    }
}