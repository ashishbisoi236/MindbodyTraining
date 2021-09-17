using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class DishRepo : IDishRepo
    {
        private readonly DishDbContext _dishDbContext;

        public DishRepo(DishDbContext dishDbContext)
        {
            _dishDbContext = dishDbContext;
        }


        public IEnumerable<Dish> Alldishes
        {
            get
            {
                return _dishDbContext.Dishes.Include(c => c.Category);
            }
        }

        public IEnumerable<Dish> BestSeller
        {
            get
            {
                return _dishDbContext.Dishes.Include(c => c.Category).Where(d => d.IsBestSeller);
            }
        }

        public Dish GetDishById(int dishId)
        {
            return Alldishes.FirstOrDefault(d => d.DishId == dishId);
        }
    }
}
