using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: AuthenticationController
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> LoginAsync (Customers customer, string returnUrl = null)
        //{
        
       // }
    }
}
