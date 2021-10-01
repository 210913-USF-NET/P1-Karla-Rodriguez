using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Customers
    {
        public Customers() {
            Log.Debug("Customer Data Found");
        }

        public Customers(string firstname) 
        {
            this.FirstName = firstname;
        }
        
        public Customers(string firstname, string lastname, int customerId) 
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.CustomerId = customerId;
            
        }

        public int CustomerId {get; set;}

        private string _firstname;
        
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                Regex pattern = new Regex("[a-zA-Z]");

                if (value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Sorry, you have to have a first name!");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if(!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Registered names have to stick to some letters, sorry!");
                }
                else{
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
                Regex pattern = new Regex("[a-zA-Z]");

                if (value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Sorry, you have to have a last name too!");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if(!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Again, some letters please!");
                }
                else{
                    _lastname = value;
                }
            }
        }

                

        
        public List<Orders> Orders {get; set;}

        public override string ToString()
        {
            return $"ID: {this.CustomerId}, FirstName: {this.FirstName}, LastName: {this.LastName}";

        }
        public bool Equals(Customers customers)
        {
            return this.FirstName == customers.FirstName && this.LastName == customers.LastName && this.CustomerId == customers.CustomerId;
        }

    }
}
