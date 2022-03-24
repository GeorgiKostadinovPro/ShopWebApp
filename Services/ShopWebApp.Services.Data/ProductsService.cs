using ShopWebApp.Data.Common.Repositories;
using ShopWebApp.Data.Models;
using ShopWebApp.Services.Mapping;
using ShopWebApp.Web.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApp.Services.Data
{
    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task CreateProduct(InputProductModel inputProductModel)
        {
            Product product = this.productsRepository.All()
                .FirstOrDefault(p => p.Name == inputProductModel.Name && p.Description == inputProductModel.Description);

            if (product == null)
            {
                product = new Product()
                {
                   Name = inputProductModel.Name,
                   Description = inputProductModel.Description,
                   ImageURL = inputProductModel.ImageURL,
                   Price = inputProductModel.Price,
                   Stock = inputProductModel.Stock,
                };
            }

            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            Product product = this.productsRepository
                .All()
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                this.productsRepository.Delete(product);
            }

            await this.productsRepository.SaveChangesAsync();
        }

        public ICollection<ProductViewModel> GetAll()
        {
            return this.productsRepository.All().To<ProductViewModel>().Where(p => p.Stock > 0).ToList();
        }
      
        public ICollection<ProductViewModel> SearchProduct(string productName)
        {
            return this.productsRepository.All().To<ProductViewModel>()
                .Where(p => p.Name.ToLower().Contains(productName.ToLower()))
                .ToList();
        }
    }
}
