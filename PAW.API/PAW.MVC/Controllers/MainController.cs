using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;
using PAW.Data;

namespace PAW.mvc.Controllers
{
    public  abstract class MainController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoriesManager _categoriesManager;
        private readonly ISuppliersManager _suppliersManager;

        public MainController(IProductManager productManager) 
        {
            _productManager = productManager;
        }
        //Error
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productManager.CreateProduct();
        }

        public MainController(ICategoriesManager categoriesManager)
        {
            _categoriesManager = categoriesManager;
        }

        public IEnumerable<Category> GetMyCategories => _categoriesManager.CreateCategorie();

        public MainController(ISuppliersManager suppliersManager)
        {
            _suppliersManager = suppliersManager;
        }

        public IEnumerable<Supplier> GetMySuppliers => _suppliersManager.CreateSupplier();

    }
}

