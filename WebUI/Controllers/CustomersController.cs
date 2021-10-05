using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P1BL;
using Models;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CustomersController : Controller
    {
        private IBL _bl;
            public CustomersController(IBL bl)
        {
            _bl = bl;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            List<CustomersVM> allCusto = _bl.GetAllCustomers()
                .Select(c => new CustomersVM(c))
                .ToList();
            return View(allCusto);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersVM customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddCustomers(customer.ToModel());
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(new CustomersVM(_bl.GetOneCustomerById(id)));
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomersVM customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateCustomers(customer.ToModel());
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new CustomersVM(_bl.GetOneCustomerById(id)));
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bl.RemoveCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
