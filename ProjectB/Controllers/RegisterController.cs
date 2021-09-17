using Microsoft.AspNetCore.Mvc;
using ProjectB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Checkout");
            }
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.CheckoutMsg = "Thanks for you order. You'll soon receive you food! ";
            return View();

        }
    }
}
