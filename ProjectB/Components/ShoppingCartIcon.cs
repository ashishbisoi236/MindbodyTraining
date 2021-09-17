using Microsoft.AspNetCore.Mvc;
using ProjectB.Models;
using ProjectB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Components
{
    public class ShoppingCartIcon:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartIcon(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(shoppingCartViewModel);
        }
    }
}
