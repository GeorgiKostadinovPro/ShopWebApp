namespace ShopWebApp.Web.Controllers
{
    using System.Diagnostics;

    using ShopWebApp.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using ShopWebApp.Services.Data;

    public class HomeController : BaseController
    {
        private readonly IProductsService productsService;
        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }    
        public IActionResult Index()
        {
            return this.View();
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
