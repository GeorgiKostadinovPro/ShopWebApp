using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Web.ViewModels.Products
{
    public class InputProductModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
