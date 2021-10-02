using System;
using System.Collections.Generic;
using Models;

namespace P1BL
{
    public interface IBL
    {
        List<Customers> GetAllCustomers();

        Customers AddCustomers(Customers custo);

        Customers UpdateCustomers(Customers customerToUpdate);

        List<Customers> SearchCustomers(string queryStr);

        Orders AddOrder(Orders orders);

        Customers GetOneCustomerById(int id);

        //Products GetOneProductById(int id);

        //Inventory UpdateInventory(Inventory invToupdate);

        //List<Products> GetAllProducts();

        //List<Products> SearchProducts(string queryStr);

        //List<VendorBranches> GetAllVendorBranches();

        //VendorBranches SelectBranch(int id);

        
        
    }
}
