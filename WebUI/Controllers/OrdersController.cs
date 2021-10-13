using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using P1BL;
using WebUI.Models;
using WebUI.Controllers.WebUI.Controllers;

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
                _bl.AddOrder(order);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "Home");
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
