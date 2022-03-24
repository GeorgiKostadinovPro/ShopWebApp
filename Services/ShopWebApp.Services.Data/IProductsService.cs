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

        Task Update(int productId, InputProductModel inputProductModel);

        ICollection<ProductViewModel> GetAll();
    }
}
