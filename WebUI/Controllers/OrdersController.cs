using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using P1BL;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class OrdersController : Controller
    {
        // GET: OrdersController
        private static Customers currentCustomer = CustomersController.currentCustomer;

        private IBL _bl;

        

        public OrdersController(IBL bl)
        {
            _bl = bl;
        }


        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orders order)
        {
            try
            {

                int CustomerQuantity = order.Quantity;
                int ProductsId = order.ProductsId;
                int VendorId = order.VendorBranchesId;

                _bl.AddOrder(order);
                //Inventory inv = _bl.GetOneInventoryById(VendorId);
                //Customers cust = _bl.GetOneCustomerById(1);
                

                //cust.FirstName = "Test";
                _bl.subtractFromStock(3, 1, 2, CustomerQuantity);

                //foreach (Inventory Inv in currentInv)
                //{
                //    if(Inv.ProductsId == ProductsId && Inv.VendorBranchesId == VendorId)
                //    {
                //        Inv.Quantity -= CustomerQuantity;

                //_bl.Save();

                //    }

                //}


                //List<VendorBranches> allVendors = _bl.GetAllVendorBranches();
                //List<Inventory> allInv = allVendors[VendorId].Inventory;

                //int currentQuantity = allInv[ProductsId].Quantity;

                //int newQuantity = currentQuantity - CustomerQuantity;
                //allVendors[VendorId].Inventory[ProductsId].Quantity = newQuantity;

                //call function here for inventory

                return RedirectToAction("Index", "Home");

            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
