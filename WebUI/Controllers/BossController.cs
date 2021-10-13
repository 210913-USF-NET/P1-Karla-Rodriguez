using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using P1BL;

namespace WebUI.Controllers
{
    public class BossController : Controller
    {
        // GET: BossController

        private static Customers currentCustomer = CustomersController.currentCustomer;

        private IBL _bl;


        public BossController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: BossController/Details/5
       

        
        public ActionResult InvList()
        {
            List<Inventory> allInv = _bl.GetAllInventory();
            
            return View(allInv);
        }


        public ActionResult InvCreate()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvCreate(Inventory inventory)
        {
            try
            {
                _bl.AddInventory(inventory);
                return RedirectToAction(nameof(InvList));
            }
            catch
            {
                return View();
            }
        }


        //public ActionResult Replenish(int id)
        //{
        //    return View(new Inventory(_bl.custTest(id)));
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Replenish(int id, Inventory quantity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateInventory(quantity);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Replenish));
            }
            catch
            {
                return RedirectToAction(nameof(Replenish));
            }
        }




        public ActionResult VendorList()
        {
            List<VendorBranches> allVendors = _bl.GetAllVendorBranches();
            return View(allVendors);

        }

        //public void SubtractQuantityFromInventory(Orders order)
        //{
        //    int CustomerQuantity = order.Quantity;
        //    int ProductsId = order.ProductsId;
        //    int VendorId = order.VendorBranchesId;
        //    List<VendorBranches> allVendors = _bl.GetAllVendorBranches();
        //    int currentQuantity = allVendors[VendorId].Inventory[ProductsId].Quantity;

        //    int newQuantity = currentQuantity - CustomerQuantity;
        //    allVendors[VendorId].Inventory[ProductsId].Quantity = newQuantity;

        //    return;
        //}

        public ActionResult VendorCreate()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendorCreate(VendorBranches vendor)
        {
            try
            {
                _bl.AddBranches(vendor);
                return RedirectToAction(nameof(VendorList));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ProductList()
        {
            List<Products> allProducts = _bl.GetAllProducts();
            return View(allProducts);
        }


        public ActionResult ProductCreate()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate(Products product)
        {
            try
            {

                {
                    _bl.AddProducts(product);
                    return RedirectToAction(nameof(ProductList));
                }

            }

            catch
            {
                return View();
            }
        }
    }
}
