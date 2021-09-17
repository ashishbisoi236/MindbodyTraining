using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class InMemoryDishRepo : IDishRepo
    {
         List<Dish> _dishes;
        public InMemoryDishRepo()
        {
            _dishes = new List<Dish>
            {
                new Dish{
                DishId = 1,
                DishName = "Aloo Posto",
                Price = 230,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 3,
                },
                new Dish{
                DishId = 2,
                DishName = "Doi Maach",
                Price = 330,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 3,
                },
                new Dish{
                DishId = 3,
                DishName = "Rasmalai",
                Price = 100,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 3,
                },

                new Dish{
                DishId = 4, 
                DishName = "Aloo Paratha",
                Price = 200,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 1,
                },
                new Dish{
                DishId = 5,
                DishName = "Makki Roti",
                Price = 300,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 1,
                },
                new Dish{
                DishId = 6,
                DishName = "Mawa Kachori",
                Price = 350,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 2,
                },
                new Dish{
                DishId = 7,
                DishName = "Mirchi Bada",
                Price = 150,
                Description = "lorem ipsum",
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsBestSeller = true,
                CategoryId = 2,
                },
            };
        }

        public IEnumerable<Dish> Alldishes {
            get
            {
                return _dishes;
            }
        }

        public IEnumerable<Dish> BestSeller => throw new NotImplementedException();

        //public IEnumerable<Dish> BestSeller { 
        //    get
        //    {
        //        return _dishes;
        //    }
        //}

        public IEnumerable<Dish> GetAllDishes()
        {
            return _dishes.OrderBy(rec => rec.DishName);
        }

        public Dish GetDishById()
        {
            throw new NotImplementedException();
        }

        public Dish GetDishById(int dishId)
        {
            throw new NotImplementedException();
        }
    }
}
