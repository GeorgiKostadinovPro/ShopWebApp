using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Web.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
