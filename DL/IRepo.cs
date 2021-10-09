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
        Inventory UpdateInventory(Inventory invToUpdate);

        //Inventory QuantityInventory(Inventory invenotryQuantity, int input);




        Products AddProducts(Products product);
        List<Products> GetAllProducts();

        List<Products> SearchProducts(string queryStr);

        Products GetOneProductById(int id);





        VendorBranches AddBranches(VendorBranches vendor);
        List<VendorBranches> GetAllVendorBranches();
        VendorBranches SelectBranch(int id);



        //List<LineItem> AddLineItem(List<LineItem> lineitem);
        //List<LineItem> GetLineItembyOrderID(int ID);

    }
}