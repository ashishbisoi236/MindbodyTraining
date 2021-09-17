using Microsoft.AspNetCore.Mvc;
using ProjectB.Models;
using ProjectB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishRepo _dishRepo;
        private readonly ICategoryRepo _categoryRepo;
        // Dependency injection
        public DishController(IDishRepo dishRepo, ICategoryRepo categoryRepo)
        {
            _dishRepo = dishRepo;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index(string category)
        {
            IEnumerable<Dish> dishes;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                dishes = _dishRepo.Alldishes.OrderBy(d=>d.DishId);
                currentCategory = "All Dishes";
            }
            else
            {
                dishes = _dishRepo.Alldishes.Where(d => d.Category.CategoryName == category).OrderBy(d => d.DishId);
                currentCategory = _categoryRepo.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new DishesListViewModel { 
                Dishes = dishes,
                CurrentCategory = currentCategory

            });
        }

        public IActionResult Details(int id)
        {
            var dish = _dishRepo.GetDishById(id);
            if(dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
