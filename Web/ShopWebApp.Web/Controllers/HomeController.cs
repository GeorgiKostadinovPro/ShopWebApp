namespace ShopWebApp.Web.Controllers
{
    using System.Diagnostics;

    using ShopWebApp.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using ShopWebApp.Services.Data;
    using ShopWebApp.Web.ViewModels.Products;

    public class HomeController : BaseController
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            AllSearchedProductsViewModel allProducts = new AllSearchedProductsViewModel()
            {
                Products = this.productsService.GetAll(),
            };

            return this.View(allProducts);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
