using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectB.Models
{
    public class ShoppingCart
    {
        private readonly DishDbContext _dishDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(DishDbContext dishDbContext)
        {
            _dishDbContext = dishDbContext;
        }

        //GetCart/AddtoCart/RemoveFromcart/GetShoppingitems/clear cart/gettotal

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DishDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        public void AddToCart(Dish dish, int amount)
        {
            var shoppingCartItem =
                _dishDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Dish.DishId == dish.DishId && s.ShoppingCartId == ShoppingCartId);
            
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Dish = dish,
                    Quantity = 1
                };
                _dishDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _dishDbContext.SaveChanges();

        }

        public int RemoveFromCart(Dish dish)
        {
            var shoppingCartItem =
                _dishDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Dish.DishId == dish.DishId && s.ShoppingCartId == ShoppingCartId);

            var localquantity = 0;
            
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localquantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _dishDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }                
            }
            _dishDbContext.SaveChanges();

            return localquantity;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (
                ShoppingCartItems =
                _dishDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Dish)
                .ToList()
                );
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _dishDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Dish.Price * c.Quantity).Sum();

            return total;
        }
    }
}
