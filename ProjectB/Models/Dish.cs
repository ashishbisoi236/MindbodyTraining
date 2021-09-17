using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsBestSeller { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
