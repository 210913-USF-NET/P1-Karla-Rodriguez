using System.Collections.Generic;
using Models;
using DL;
using System;

namespace P0BL 
{
    public class BL : IBL
    {
        
            private IRepo _repo;
            //you are using dependency injection here
            public BL(IRepo repo)
            {
                _repo = repo;
            }
        public List<Customers> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public Customers AddCustomers (Customers custo)
        {
            return _repo.AddCustomers(custo);
        }
        public Customers UpdateCustomers(Customers custoToUpdate)
        {
            return _repo.UpdateCustomers(custoToUpdate);
        }
        public List<Customers> SearchCustomers(string queryStr)
        {
            return _repo.SearchCustomers(queryStr);
        }
        public Orders AddOrder(Orders order)
        {
            return _repo.AddOrder(order);
        }
        public Customers GetOneCustomerById(int id)
        {
            return _repo.GetOneCustomerById(id);
        }

        public Inventory UpdateInventory(Inventory invToupdate)
        {
            return _repo.UpdateInventory(invToupdate);
        }
        public List<Products> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public Products GetOneProductById(int id)
        {
            return _repo.GetOneProductById(id);
        }
        public List<Products> SearchProducts(string queryStr)
        {
            return _repo.SearchProducts(queryStr);
        }
        public List<VendorBranches> GetAllVendorBranches()
        {
            return _repo.GetAllVendorBranches();
        }
        public VendorBranches SelectBranch(int id)
        {
            return _repo.SelectBranch(id);
        }



    }
}