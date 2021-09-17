using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class SearchBox
    {
        private readonly DishDbContext _dishDbContext;
        public SearchBox(DishDbContext dishDbContext)
        {
            _dishDbContext = dishDbContext;
        }
    }
}
