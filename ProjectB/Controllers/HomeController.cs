using Microsoft.AspNetCore.Mvc;
using ProjectB.Models;
using ProjectB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDishRepo _dishRepo;
        // DI
        public HomeController(IDishRepo dishRepo)
        {
            _dishRepo = dishRepo;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                BestSeller = _dishRepo.BestSeller
            };
            return View(homeViewModel);
        }
    }
}
