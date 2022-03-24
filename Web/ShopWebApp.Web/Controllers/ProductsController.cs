using Microsoft.AspNetCore.Mvc;
using ShopWebApp.Services.Data;
using ShopWebApp.Web.ViewModels.Products;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputProductModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.productsService.CreateProduct(inputModel);
            return this.Redirect("/");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.productsService.DeleteProduct(id);

            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Search(InputSearchModel searchModel)
        {
            AllSearchedProductsViewModel allSearchedProductsModel = new AllSearchedProductsViewModel
            {
                Products = this.productsService.SearchProduct(searchModel.Name),
            };

            return this.View(allSearchedProductsModel);
        }
    }
}
