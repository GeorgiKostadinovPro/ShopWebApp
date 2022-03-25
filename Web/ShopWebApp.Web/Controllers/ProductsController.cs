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

        public IActionResult Update(int id)
        {
            var inputModel = this.productsService.GetProductById<EditProductInputModel>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, EditProductInputModel product)
        {
            if (!this.ModelState.IsValid)
            {
                product.Id = id;
                return this.View(product);
            }

            await this.productsService.UpdateProduct(id, product);

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
