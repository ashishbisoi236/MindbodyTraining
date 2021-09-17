using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class InMemoryCategoryRepo : ICategoryRepo
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category{CategoryId=1, CategoryName="Punjabi", Description="Punjabi cuisine is famous all over the country for its delicious flavor."},
            new Category{CategoryId=2, CategoryName="Rajasthani", Description="The state of Rajasthan is widely known for its distinct variety of dishes."},
            new Category{CategoryId=3, CategoryName="Bengali", Description="Bengali food is a combination of fish, rice, and lentils."}
        };
    }
}
