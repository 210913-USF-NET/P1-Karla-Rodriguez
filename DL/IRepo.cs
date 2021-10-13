using Models;
using System.Collections.Generic;


namespace DL
{
    public interface IRepo
    {
        Customers AddCustomers(Customers custo);
        List<Customers> GetAllCustomers();

        Customers UpdateCustomers(Customers customerToUpdate);
        List<Customers> SearchCustomers(string FirstName, string Address);
        Customers GetOneCustomerById(int id);

        void RemoveCustomer(int id);

     

        Orders AddOrder(Orders order);

        Inventory AddInventory(Inventory inventory);

        void custTest(int id);
        Inventory UpdateInventory(Inventory quantityToUpdate);

        //Inventory QuantityInventory(Inventory invenotryQuantity, int input);
        List<Inventory> GetAllInventory();

        Inventory GetOneInventoryById(int id);

        void subtractFromStock(int id, int productsID, int VendorBranchesId, int quantity);

        Products AddProducts(Products product);
        List<Products> GetAllProducts();

        List<Products> SearchProducts(string queryStr);

        Products GetOneProductById(int id);


        void Save();


        VendorBranches AddBranches(VendorBranches vendor);
        List<VendorBranches> GetAllVendorBranches();
        VendorBranches SelectBranch(int id);



        //List<LineItem> AddLineItem(List<LineItem> lineitem);
        //List<LineItem> GetLineItembyOrderID(int ID);

    }
}