using ShopWebApp.Data.Common.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebApp.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

    }
}
