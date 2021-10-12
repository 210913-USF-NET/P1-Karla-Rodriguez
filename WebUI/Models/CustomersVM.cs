using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CustomersVM
    {
        public CustomersVM() { }

        public CustomersVM(Customers custo)
        {
            this.Id = custo.Id;
            this.FirstName = custo.FirstName;
            this.LastName = custo.LastName;
            this.Address = custo.Address;
        }

        public int Id { get; set; }

        public List<Orders> Orders { get; set; }

        public string Address { get; set; }

        
        [Required]
        [RegularExpression("^[a-zA-Z_ ]+$", ErrorMessage = "Please enter name with valid characters")]
        
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z_ ]+$", ErrorMessage = "Please enter name with valid characters")]
        public string LastName { get; set; }

        public Customers ToModel()
        {
            Customers newCusto;
            try
            {
                newCusto = new Customers
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Address = this.Address
                };
            }

            catch
            {
                throw;
            }
            return newCusto;
        }

        
    }
}
