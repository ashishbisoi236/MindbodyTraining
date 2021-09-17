using Microsoft.AspNetCore.Mvc;
using ProjectB.Models;
using ProjectB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDishRepo _dishRepo;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IDishRepo dishRepo, ShoppingCart shoppingCart)
        {
            _dishRepo = dishRepo;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int dishId)
        {
            var selectedDish = _dishRepo.Alldishes.FirstOrDefault(d => d.DishId == dishId);
            if (selectedDish != null)
            {
                _shoppingCart.AddToCart(selectedDish, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int dishId)
        {
            var selectedDish = _dishRepo.Alldishes.FirstOrDefault(d => d.DishId == dishId);
            if (selectedDish != null)
            {
                _shoppingCart.RemoveFromCart(selectedDish);
            }
            return RedirectToAction("Index");
        }
    }
}
