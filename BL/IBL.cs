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

        List<Customers> SearchCustomers(string FirstName, string Address);

        Customers GetOneCustomerById(int id);

        void RemoveCustomer(int id);

        void Save();


        Products AddProducts(Products product);
        Products GetOneProductById(int id);
        List<Products> GetAllProducts();

        List<Products> SearchProducts(string queryStr);


        Inventory GetOneInventoryById(int id);

        void subtractFromStock(int id, int productsID, int VendorBranchesId, int quantity);

        Orders AddOrder(Orders orders);


        Inventory AddInventory(Inventory inventory);

        void custTest(int Id);

        Inventory UpdateInventory(Inventory quantityToUpdate);

        List<Inventory> GetAllInventory();





        VendorBranches AddBranches(VendorBranches vendor);

        List<VendorBranches> GetAllVendorBranches();

        VendorBranches SelectBranch(int id);



    }
}
