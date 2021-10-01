using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Customers
    {

        public Customers() { }

        public Customers(string FirstName) : this()
        {
            this.FirstName = FirstName;

        }

        public Customers(string firstname, string LastName) : this(firstname)
        {
            this.LastName = LastName;

        }

        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Orders> Orders {get; set;}

        public override string ToString()
        {
            return $"ID: {this.CustomerId}, FirstName: {this.FirstName}, LastName: {this.LastName}";

        }

    }
}
