using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1BL;
using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController

        private IBL _bl;
        public ProductController(IBL bl)
        {
            _bl = bl;
        }
        
        public ActionResult List()
        {
            List<Products> allProducts = _bl.GetAllProducts();
            return View(allProducts);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            try
            {
                
                {
                    _bl.AddProducts(product);
                    return RedirectToAction(nameof(List));
                }
           
            }

            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult CreateOrder()
        {
            return View();
        }
       

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(Orders order)
        {
            try
            {
                _bl.AddOrder(order);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
