using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Customers
    {

        public Customers() {
            Log.Debug("Database connection");
            this.Orders = new List<Orders>();
        }

        public Customers(string FirstName, string LastName, string Address)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
        }

        
        public int Id { get; set; }

        private string _firstname;

        
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                
                Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");

                if (value?.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Racer name can't be empty");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if (!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Racer name can only have alphanumeric characters, !, and ?.");
                }
                else
                {
                    _firstname = value;
                }
            }
        }

        private string _lastname;

        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
                if(value?.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Racer name can't be empty");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if(!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Racer name can only have alphanumeric characters, !, and ?.");
                }
                else
                {
                    _lastname = value;
                }
            }
        }
        public string Address { get; set; }

        public List<Orders> Orders {get; set;}

        public override string ToString()
        {
            return $"ID: {this.Id}, FirstName: {this.FirstName}, LastName: {this.LastName}, Address: {this.Address}";

        }
        public bool Equals(Customers customer)
        {
            return this.FirstName == customer.FirstName && this.Address == customer.Address;
        }
    }
}
