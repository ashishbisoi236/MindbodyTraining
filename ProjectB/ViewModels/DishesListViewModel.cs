using ProjectB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.ViewModels
{
    public class DishesListViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public string CurrentCategory { get; set; }
    }
}
