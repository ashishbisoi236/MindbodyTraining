using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public interface IDishRepo
    {
        IEnumerable<Dish> Alldishes { get; }
        IEnumerable<Dish> BestSeller { get; }
        Dish GetDishById(int dishId);
    }
}
