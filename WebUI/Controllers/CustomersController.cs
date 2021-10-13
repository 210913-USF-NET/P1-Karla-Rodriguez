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
    namespace WebUI.Controllers
    {
        public class CustomersController : Controller
        {
            public static Customers currentCustomer;

            private IBL _bl;


            public CustomersController(IBL bl)
            {
                _bl = bl;
            }
            // GET: CustomersController
            public ActionResult CustIndex()
            {
                List<CustomersVM> allCusto = _bl.GetAllCustomers()
                    .Select(c => new CustomersVM(c))
                    .ToList();
                return View(allCusto);
            }





            // GET: CustomersController/Details/5
            public ActionResult Profile()
            {
                _bl.GetOneCustomerById(currentCustomer.Id);
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
            public ActionResult Create(CustomersVM custo)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _bl.AddCustomers(custo.ToModel());
                        return RedirectToAction(nameof(Login));
                    }
                    return View();
                }
                catch (Exception e)
                {
                    return View();
                }
            }

            // GET: CustomersController/Edit/5
            public ActionResult GetOneCustomerById(int Id)
            {

                return View(new CustomersVM(_bl.GetOneCustomerById(Id)));
            }

            // POST: CustomersController/Edit/5


            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(string FirstName, string Address)
            {
                try
                {
                    var customer = _bl.SearchCustomers(FirstName, Address);
                    currentCustomer = customer[0];
                    if (customer.Count == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Wrongo");
                        return View("Login");
                    }
                    else
                    {
                        if (FirstName == "Boss" && Address == "Gold Saucer 123")
                        {
                            return RedirectToAction("Index", "Boss");
                        }
                        return RedirectToAction("Profile", "Customers");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Please try again");
                    return View("Login");
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
}