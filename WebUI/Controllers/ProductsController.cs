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
    public class ProductsController : Controller
    {
        // GET: ProductController

        private IBL _bl;



        public ProductsController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
       
    }
}
