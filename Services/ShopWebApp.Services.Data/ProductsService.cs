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
        private readonly IDeletableEntityRepository<UserProduct> usersProductsRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository, IDeletableEntityRepository<UserProduct> usersProductsRepository)
        {
            this.productsRepository = productsRepository;
            this.usersProductsRepository = usersProductsRepository;
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

            List<UserProduct> usersProducts = this.usersProductsRepository.All()
                .Where(up => up.ProductId == productId)
                .ToList();

            if (usersProducts.Count > 0)
            {
                foreach (var userProduct in usersProducts)
                {
                    this.usersProductsRepository.Delete(userProduct);
                }
            }

            this.productsRepository.Delete(product);

            await this.usersProductsRepository.SaveChangesAsync();
            await this.productsRepository.SaveChangesAsync();
        }

        public async Task UpdateProduct(int id, EditProductInputModel inputModel)
        {
            Product product = this.productsRepository.All().FirstOrDefault(p => p.Id == id);

            product.Name = inputModel.Name;
            product.Description = inputModel.Description;
            product.ImageURL = inputModel.ImageURL;
            product.Price = inputModel.Price;
            product.Stock = inputModel.Stock;

            await this.productsRepository.SaveChangesAsync();
        }

        public ICollection<ProductViewModel> GetAll()
        {
            return this.productsRepository.All().To<ProductViewModel>().Where(p => p.Stock > 0).ToList();
        }

        public T GetProductById<T>(int id)
        {
            return this.productsRepository.All()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public ICollection<ProductViewModel> SearchProduct(string productName)
        {
            return this.productsRepository.All().To<ProductViewModel>()
                .Where(p => p.Name.ToLower().Contains(productName.ToLower()))
                .ToList();
        }

        public async Task AddToUser(string userId, int productId)
        {
           Product product = this.productsRepository.All().FirstOrDefault(p => p.Id == productId);

           UserProduct userProduct = this.usersProductsRepository
                .AllWithDeleted()
                .FirstOrDefault(up => up.UserId == userId && up.ProductId == productId);

           if (userProduct == null)
           {
                await this.usersProductsRepository.AddAsync(new UserProduct { UserId = userId, ProductId = product.Id });
           }
           else
           {
                if (userProduct.IsDeleted)
                {
                    this.usersProductsRepository.Undelete(userProduct);
                }
                else
                {
                    throw new ArgumentException("You have already added this product!");
                }
           }

           await this.usersProductsRepository.SaveChangesAsync();
        }

        public async Task RemoveProductFromUserCollection(string userName, int productId)
        {
            UserProduct userProduct = this.usersProductsRepository.All()
                .FirstOrDefault(up => up.User.UserName == userName && up.ProductId == productId);

            this.usersProductsRepository.Delete(userProduct);

            await this.usersProductsRepository.SaveChangesAsync();
        }

        public ICollection<UserProductViewModel> GetAllPerUser(string username)
        {
            return this.usersProductsRepository.All()
                .To<UserProductViewModel>()
                .Where(up => up.UserName == username)
                .ToList();
        }
    }
}
