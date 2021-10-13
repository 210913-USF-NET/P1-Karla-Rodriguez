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
        [Fact]
        public void GetAllCustomersShoulddGetAllCustomers()
        {
            using (var context = new P1DBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var customers = repo.GetAllCustomers();

                //Assert
                Assert.Equal(2, customers.Count);
            }
        }


     
        [Fact]
        public void AddingACustomerShouldAddACustomer()
        {
            using (var context = new P1DBContext(options))
            {
                
                IRepo repo = new DBRepo(context);
                Models.Customers custoToAdd = new Models.Customers()
                {
                    Id = 15,
                    FirstName = "Sleepy",
                    LastName = "Robins",
                    Address = "123 Red Street"
                };

                //Act
                repo.AddCustomers(custoToAdd);
            }

            using (var context = new P1DBContext(options))
            {
                //Assert
                Customers custo = context.Customers.FirstOrDefault(c => c.Id == 3);

                Assert.NotNull(custo);
                Assert.Equal("Sleepy", custo.FirstName);
                Assert.Equal("Robins", custo.LastName);
                Assert.Equal("123 Red Street", custo.Address);
            }
        }

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
                        Orders = new List<Orders>(){
                            new Orders(){
                                Id = 1,
                                ProductsId = 1,
                                VendorBranchesId = 1,
                            }
                        }
                    },
                    new Customers()
                    {
                        Id = 17,
                        FirstName = "Fish",
                        LastName = "Eyes",
                        Address = "857 Green Street",
                        Orders = new List<Orders>(){
                            new Orders(){
                                Id = 1,
                                ProductsId = 1,
                                VendorBranchesId = 1,
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
