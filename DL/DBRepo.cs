using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

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
        
        public Customers AddCustomers(Customers custo)
        {
         
            custo = _context.Add(custo).Entity;

            
            _context.SaveChanges();

            
            _context.ChangeTracker.Clear();

            return custo;
        }

        public List<Customers> GetAllCustomers()
        {
            
            return _context.Customers
                .Include("Orders")
                .Select(
                customer => new Customers() {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address
                }
            ).ToList();

            
        }

        public Customers UpdateCustomers(Customers customersToUpdate)
        {
            Customers custoToUpdate = new Customers() {

                CustomerId = customersToUpdate.CustomerId,
                FirstName = customersToUpdate.FirstName,
                LastName = customersToUpdate.LastName,
                Address = customersToUpdate.Address
                
            };

            custoToUpdate = _context.Customers.Update(custoToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customers() {
                CustomerId = custoToUpdate.CustomerId,
                FirstName = custoToUpdate.FirstName,
                LastName = custoToUpdate.LastName,
                Address = custoToUpdate.Address
                
            };
        }

        public List<Customers> SearchCustomers(string queryStr)
        {
            return _context.Customers.Where(
                custo => custo.FirstName.Contains(queryStr) || custo.LastName.Contains(queryStr) 
            ).Select(
                c => new Customers(){
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address
                    
                }
            ).ToList();
        }

        public Orders AddOrder(Orders order)
        {
            order = _context.Add(order).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Orders() {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                VendorId = order.VendorId,
                Date = order.Date
            };
        }

        
        public Customers GetOneCustomerById(int id)
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

        public Models.Inventory UpdateInventory(Models.Inventory inventoryToupdate)
        {
            Inventory invToUpdate = new Inventory() {
                InventoryId = inventoryToupdate.InventoryId,
                ProductId = inventoryToupdate.ProductId,
                VendorId = inventoryToupdate.VendorId,
                Quantity = inventoryToupdate.Quantity
            };

            _context.Inventories.Update(invToUpdate);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return invToUpdate;
        }
        public List<Products> GetAllProducts()
        {

            return _context.Products.Select(
                product => new Products()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = (decimal)product.Price,
                    Description = product.Description
                }
            ).ToList();
        }

        public List<Products> SearchProducts(string queryStr)
        {
            return _context.Products.Where(
                prod => prod.Name.Contains(queryStr) || prod.Description.Contains(queryStr)
            ).Select(
                p => new Products()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = (decimal)p.Price,
                    Description = p.Description,
                }
            ).ToList();
        }
        public VendorBranches SelectBranch(int id)
        {
            VendorBranches vendorById = _context.VendorBranches
            .Include("Inventory")
            .FirstOrDefault(v => v.VendorId == id);
            return new VendorBranches()
            {
                VendorId = vendorById.VendorId,
                Name = vendorById.Name,
                CityState = vendorById.CityState
            };
        }

        public List<VendorBranches> GetAllVendorBranches()
        {

            return _context.VendorBranches.Select(
                vendor => new VendorBranches()
                {
                    VendorId = vendor.VendorId,
                    Name = vendor.Name,
                    CityState = vendor.CityState
                }
            ).ToList();
        }

        public Products GetOneProductById(int id)
        {
            Products prodById =
                _context.Products

                .FirstOrDefault(prod => prod.ProductId == id);


            return new Products()
            {
                ProductId = prodById.ProductId,
                Name = prodById.Name,
                Price = (decimal)prodById.Price,
                Description = prodById.Description,


            };
        }

        
    }
}

