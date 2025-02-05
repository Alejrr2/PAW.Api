using PAW.Models;

namespace PAW.Business
{
    public interface ICategoriesManager
    {
        IEnumerable<Category> CreateCategorie();
    }

    public class CategoryManager : ICategoriesManager
    {
        public IEnumerable<Category> CreateCategorie()
        {
            var categories = new List<Category>();
            for (var i = 0; i < 1000; i++)
                categories.Add(new Category
                {
                    CategoryId = i+1000,
                    CategoryName = i % 2 == 0 ? "Beverage" : "Condiments",
                    Description = i % 2 == 0 ? "Soft drinks, coffees, teas, beers, and ales" : "Sweet and savory sauces, relishes, spreads, and seasonings",
                });

            return categories;
        }
    }
}
