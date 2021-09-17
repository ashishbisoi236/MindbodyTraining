using Microsoft.AspNetCore.Mvc;
using ProjectB.Models;
using ProjectB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Controllers
{
    public class SearchBoxController : Controller
    {
        private readonly IDishRepo _dishRepo;
        public SearchBoxController(IDishRepo dishRepo)
        {
            _dishRepo = dishRepo;
        }

        public ActionResult Index(string dishName)
        {
            // All dishes
            var dishes = _dishRepo.Alldishes;
            Console.WriteLine(dishes.Count());
            if (!String.IsNullOrEmpty(dishName))
            {
                dishes = dishes.Where(d => d.DishName.ToLower().Contains(dishName.ToLower()));
            }
            return View(new DishesListViewModel
            {
                Dishes = dishes,
            });
            //return View(dishes.ToList());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
