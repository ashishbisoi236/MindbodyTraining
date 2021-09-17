using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly DishDbContext _dishDbContext;

        public CategoryRepo(DishDbContext dishDbContext)
        {
            _dishDbContext = dishDbContext;
        }

        public IEnumerable<Category> AllCategories => _dishDbContext.Categories;
    }
}
