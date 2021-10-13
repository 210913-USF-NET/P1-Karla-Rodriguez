using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class P1DBContext : DbContext
    {
        public P1DBContext() : base() { }
        public P1DBContext(DbContextOptions<P1DBContext> options) : base(options) { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        //public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<VendorBranches> VendorBranches { get; set; }

    }
}
