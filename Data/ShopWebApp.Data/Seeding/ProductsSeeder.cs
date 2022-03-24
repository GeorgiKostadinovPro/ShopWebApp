using ShopWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApp.Data.Seeding
{
    public class ProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any())
            {
                return;
            }

            ICollection<Product> products = new List<Product>()
            {

                new Product
                {
                    Name = "Asus Rog Strix Scar II",
                    Description = "Intel Core i7-8750H, NVIDIA GeForce GTX 1060, 8GB DDR4, 1TB SSD NVMe + 1TB SSHD",
                    ImageURL = "https://laptop.bg/system/images/175937/original/asus_rog_strix_scar_ii_gl504gmes164_GL504GMES1641TBSSD.jpg",
                    Price = 4329.99M,
                    Stock = 20,
                },

                new Product
                {
                    Name = "Dell G5 15",
                    Description = "Intel Core i7-11800H, NVIDIA GeForce RTX 3050, 16GB DDR4, 512GB SSD NVMe",
                    ImageURL = "https://i0.wp.com/laptopmedia.com/wp-content/uploads/2019/04/g5155590.jpg",
                    Price = 3499.99M,
                    Stock = 15,
                },

                new Product
                {
                    Name = "Mac Book Pro 18",
                    Description = "Intel Core i5-1030NG7 (1.10/3.50GHz, 6M), 8 GB, 512GB SSD",
                    ImageURL = "https://s13emagst.akamaized.net/products/27417/27416786/images/res_197c9ec408671a7f8efbae2791324ef8.jpg",
                    Price = 2300M,
                    Stock = 25,
                },

                new Product
                {
                    Name = "Lenovo Legion 7",
                    Description = "Intel Core i7-10750H, NVIDIA GeForce RTX 3050 Ti, 64GB DDR4",
                    ImageURL = "https://s13emagst.akamaized.net/products/40600/40599217/images/res_d9ad9cb19b279121c56f93c1969c5396.jpg",
                    Price = 2500M,
                    Stock = 10,
                },
            };

            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
        }
    }
}
