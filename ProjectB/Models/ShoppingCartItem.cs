using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemid { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
