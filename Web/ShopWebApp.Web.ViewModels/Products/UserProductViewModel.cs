using AutoMapper;
using ShopWebApp.Data.Models;
using ShopWebApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Web.ViewModels.Products
{
    public class UserProductViewModel : IMapFrom<UserProduct>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserProduct, UserProductViewModel>()
                .ForMember(x => x.UserName, y => y.MapFrom(x => x.User.UserName))
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ProductId))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Product.Name))
                .ForMember(x => x.Description, y => y.MapFrom(x => x.Product.Description))
                .ForMember(x => x.ImageURL, y => y.MapFrom(x => x.Product.ImageURL))
                .ForMember(x => x.Price, y => y.MapFrom(x => x.Product.Price))
                .ForMember(x => x.Stock, y => y.MapFrom(x => x.Product.Stock));
        }
    }
}
