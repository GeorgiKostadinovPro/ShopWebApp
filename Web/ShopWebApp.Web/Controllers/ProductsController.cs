using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.Common;
using ShopWebApp.Data.Models;
using ShopWebApp.Services.Data;
using ShopWebApp.Web.ViewModels.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(IProductsService productsService, UserManager<ApplicationUser> userManager)
        {
            this.productsService = productsService;
            this.userManager = userManager;
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
        public IActionResult Search(AllSearchedProductsViewModel searchModel)
        {
            AllSearchedProductsViewModel allSearchedProductsModel = new AllSearchedProductsViewModel
            {
                Products = this.productsService.SearchProduct(searchModel.Search.Name),
            };

            return this.View(allSearchedProductsModel);
        }

        public async Task<IActionResult> AddProductToUser(int id)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.productsService.AddToUser(user.Id, id);
            }
            catch (Exception ex)
            {
                this.TempData["AlreadyAdded"] = ex.Message;
            }

            return this.Redirect("/");
        }

        public async Task<IActionResult> RemoveProductFromUserCollection(int id)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            await this.productsService.RemoveProductFromUserCollection(user.UserName, id);

            return this.Redirect("/");
        }

        public async Task<IActionResult> GetUserCollection()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            var userProducts = this.productsService.GetAllPerUser(user.UserName);

            return this.View(userProducts);
        }
    }
}
