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
    public class VendorBranchesController : Controller
    {
        // GET: VendorBranchesController

        private IBL _bl;
        public VendorBranchesController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult List()
        {
            List<VendorBranches> allVendors = _bl.GetAllVendorBranches();
            return View(allVendors);
        }

        // GET: VendorBranchesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendorBranchesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorBranchesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorBranches vendor)
        {
            try
            {
                _bl.AddBranches(vendor);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorBranchesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendorBranchesController/Edit/5
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

        // GET: VendorBranchesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendorBranchesController/Delete/5
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
