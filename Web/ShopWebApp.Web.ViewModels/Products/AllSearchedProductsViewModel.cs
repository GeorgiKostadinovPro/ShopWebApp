using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Web.ViewModels.Products
{
    public class AllSearchedProductsViewModel
    {
        public InputSearchModel Search { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
