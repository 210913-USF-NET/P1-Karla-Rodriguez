using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DL;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<P1DBContext> options;

        public DLTests()
        {
       
            options = new DbContextOptionsBuilder<P1DBContext>()
                        .UseSqlite("Filename=Test.db").Options;
            Seed();
        }

        //Testing Read ops
    

     
        
        private void Seed()
        {
            using (var context = new P1DBContext(options))
            {
                //first, we are going to make sure
                //that the DB is in clean slate
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customers()
                    {
                        Id = 16,
                        FirstName = "Mika",
                        LastName = "Lika",
                        Address = "345 Blue Street",
                        
                            
                        
                    },
                    new Customers()
                    {
                        Id = 17,
                        FirstName = "Fish",
                        LastName = "Eyes",
                        Address = "857 Green Street",
                        
                            
                        
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
