using ShopWebApp.Data.Models;
using ShopWebApp.Web.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApp.Services.Data
{
    public interface IProductsService
    {
        Task CreateProduct(InputProductModel inputProductModel);

        Task DeleteProduct(int productId);

        Task UpdateProduct(int id, EditProductInputModel inputModel);

        Task AddToUser(string userId, int prodcutId);

        Task RemoveProductFromUserCollection(string userName, int productId);

        ICollection<UserProductViewModel> GetAllPerUser(string username);

        ICollection<ProductViewModel> GetAll();

        T GetProductById<T>(int id);

        ICollection<ProductViewModel> SearchProduct(string productName);
    }
}
