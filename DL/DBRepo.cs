using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
//using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private P1DBContext _context;
        public DBRepo(P1DBContext context)
        {
            _context = context;
        }
        
        public Model.Customers AddCustomers(Model.Customers custo)
        {
         
            custo = _context.Add(custo).Entity;

            
            _context.SaveChanges();

            
            _context.ChangeTracker.Clear();

            return custo;
        }

        public List<Model.Customers> GetAllCustomers()
        {
            
            return _context.Customers
                .Include("Orders")
                .Select(
                customer => new Model.Customers() {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                }
            ).ToList();

            
        }

        public Model.Customers UpdateCustomers(Model.Customers customerToUpdate)
        {
            Model.Customers customersToUpdate = new Model.Customers() {
                CustomerId = customerToUpdate.CustomerId,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName
                
            };

            customersToUpdate = _context.Customers.Update(customersToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customers() {
                CustomerId = customerToUpdate.CustomerId,
                FirstName = customerToUpdate.FirstName,
                LastName = customerToUpdate.LastName
                
            };
        }

        public List<Model.Customers> SearchCustomers(string queryStr)
        {
            return _context.Customers.Where(
                custo => custo.FirstName.Contains(queryStr) || custo.LastName.Contains(queryStr) 
            ).Select(
                c => new Model.Customers(){
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    
                }
            ).ToList();
        }

        public Model.Orders AddOrder(Model.Orders order)
        {
            Model.Orders orderToAdd = new Model.Orders(){
                CustomerId = order.CustomerId,
                

            };
            orderToAdd = _context.Orders.Add(orderToAdd).Entity;
            _context.SaveChanges();

            return new Model.Orders() {
                OrderId = orderToAdd.OrderId,
                CustomerId = orderToAdd.OrderId,
                ProductId = orderToAdd.OrderId
            };
        }

        
        public Model.Customers GetOneCustomerById(int id)
        {
            return _context.Customers
                
                .AsNoTracking()
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.CustomerId == id);

          
        }

        public void RemoveCustomer(int id)
        {
            _context.Customers.Remove(GetOneCustomerById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        //public Models.Inventory UpdateInventory(Models.Inventory invToupdate)
        //{
        //    Inventory invtoUpdate = new Inventory();
        //    ProductId = invToupdate.ProductId;
        //    VendorId = invToupdate.VendorId;
        //    Quantity = invToupdate.Quantity;
            
        //    _context.Inventories.Update(invtoAdd);
        //    _context.SaveChanges();
        //    _context.ChangeTracker.Clear();
        //    return invToupdate;
        //}
        //public List<Model.Products> GetAllProducts()
        //{
            
        //    return _context.Products.Select(
        //        product => new Model.Products() {
        //            ProductId = product.Id,
        //            Name = product.Name,
        //            Price = (decimal)product.Price,
        //            Description = product.Description
        //        }
        //    ).ToList();
        //}

        //public List<Model.Products> SearchProducts(string queryStr)
        //{
        //    return _context.Products.Where(
        //        prod => prod.Name.Contains(queryStr) ||  prod.Description.Contains(queryStr)
        //    ).Select(
        //        p => new Model.Products(){
        //            Name = p.Name,
        //            Price = (decimal)p.Price, 
        //            Description = p.Description,
        //        }
        //    ).ToList();
        //}
        //public Model.VendorBranches SelectBranch(int id)
        //{
        //    VendorBranch vendorById = _context.VendorBranches
        //    .Include("Inventory")
        //    .FirstOrDefault(v => v.Id == id);
        //    return new Model.VendorBranches()
        //    {
        //        VendorId = vendorById.Id,
        //        Name = vendorById.Name,
        //        CityState = vendorById.CityState
        //    };
        //}

        //    public List<Model.VendorBranches> GetAllVendorBranches()
        //{
            
        //    return _context.VendorBranches.Select(
        //        vendor => new Model.VendorBranches() {
        //            VendorId = vendor.Id,
        //            Name = vendor.Name,
        //            CityState = vendor.CityState
        //        }
        //    ).ToList();
        //}
    
        //public Model.Products GetOneProductById(int id)
        //{
        //    Product prodById = 
        //        _context.Products
                
        //        .FirstOrDefault(prod => prod.Id == id);
                

        //    return new Model.Products() {
        //        ProductId = prodById.Id,
        //        Name = prodById.Name,
        //        Price = (decimal)prodById.Price,
        //        Description = prodById.Description,
                        
                    
        //        };
        //    }
        }
    }

