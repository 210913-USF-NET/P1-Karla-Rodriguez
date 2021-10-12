using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
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
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address
                }
            ).ToList();

            
        }

        public Customers UpdateCustomers(Customers customersToUpdate)
        {
            Customers custoToUpdate = new Customers() {

                Id = customersToUpdate.Id,
                FirstName = customersToUpdate.FirstName,
                LastName = customersToUpdate.LastName,
                Address = customersToUpdate.Address
                
            };

            custoToUpdate = _context.Customers.Update(custoToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customers() {
                Id = custoToUpdate.Id,
                FirstName = custoToUpdate.FirstName,
                LastName = custoToUpdate.LastName,
                Address = custoToUpdate.Address
                
            };
        }

        public List<Customers> SearchCustomers(string FirstName, string Address)
        {
            return _context.Customers.Where(
                custo => custo.FirstName.Contains(FirstName) && custo.Address.Contains(Address) 
            ).Select(
                c => new Customers(){
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address
                    
                }
            ).ToList();
        }

        

        public Orders AddOrder(Orders order)
        {
            //foreach (LineItem item in order.LineItems)
            //{
            //    LineItem itemToAdd = new LineItem()
            //    {
            //        VendorBranchesId = item.Id,
            //        ProductsId = item.ProductsId,
            //        Quantity = (int)item.Quantity,
            //        OrdersId = order.Id
            //    };
            //    itemToAdd = _context.Add(itemToAdd).Entity;
            //    _context.SaveChanges();
            //    _context.ChangeTracker.Clear();
            //}

           
            _context.Add(order);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return order;
        }


       
        
        public Customers GetOneCustomerById(int id)
        {
            return _context.Customers
                
                .AsNoTracking()
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);

          
        }

        public void RemoveCustomer(int id)
        {
            _context.Customers.Remove(GetOneCustomerById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }


        public Inventory AddInventory(Inventory inventory)
        {

            Inventory invToAdd = new Inventory()
            {
                VendorBranchesId = inventory.VendorBranchesId,
                ProductsId = inventory.ProductsId,
                Quantity = inventory.Quantity
            };

            invToAdd = _context.Add(invToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Inventory()
            {
                Id = invToAdd.Id,
                VendorBranchesId = invToAdd.VendorBranchesId,
                ProductsId = invToAdd.ProductsId,
                Quantity = invToAdd.Quantity
            };
        }




        public List<Inventory> GetAllInventory()
        {

            return _context.Inventory.Select(
                inventory => new Inventory()
                {
                    Id = inventory.Id,
                    ProductsId = inventory.ProductsId,
                    VendorBranchesId = inventory.VendorBranchesId,
                    Quantity = inventory.Quantity
                }
            ).ToList();


        }


        public Models.Inventory UpdateInventory(Models.Inventory inventoryToupdate)
        {
            Inventory invToUpdate = new Inventory() {
                Id = inventoryToupdate.Id,
                ProductsId = inventoryToupdate.ProductsId,
                VendorBranchesId = inventoryToupdate.VendorBranchesId,
                Quantity = inventoryToupdate.Quantity
            };

            _context.Inventory.Update(invToUpdate);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return invToUpdate;
        }

        public Products AddProducts(Products product)
        {

            product = _context.Add(product).Entity;


            _context.SaveChanges();


            _context.ChangeTracker.Clear();

            return product;
        }

        public List<Products> GetAllProducts()
        {

            return _context.Products.Select(
                product => new Products()
                {
                    Id = product.Id,
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
                    Id = p.Id,
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
            .FirstOrDefault(v => v.Id == id);
            return new VendorBranches()
            {
                Id = vendorById.Id,
                Name = vendorById.Name,
                GrandCompany = vendorById.GrandCompany,
                CityState = vendorById.CityState
            };
        }


        public VendorBranches AddBranches(VendorBranches vendor)
        {

            vendor = _context.Add(vendor).Entity;


            _context.SaveChanges();


            _context.ChangeTracker.Clear();

            return vendor;
        }



        public List<VendorBranches> GetAllVendorBranches()
        {

            return _context.VendorBranches.Select(
                vendor => new VendorBranches()
                {
                    Id = vendor.Id,
                    Name = vendor.Name,
                    GrandCompany = vendor.GrandCompany,
                    CityState = vendor.CityState
                }
            ).ToList();
        }

        public Products GetOneProductById(int id)
        {
            Products prodById =
                _context.Products

                .FirstOrDefault(prod => prod.Id == id);


            return new Products()
            {
                Id = prodById.Id,
                Name = prodById.Name,
                Price = (decimal)prodById.Price,
                Description = prodById.Description,


            };
        }



     


    }
}

