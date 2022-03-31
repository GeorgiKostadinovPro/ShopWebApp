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

        public DateTime AddedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserProduct, UserProductViewModel>()
                .ForMember(x => x.UserName, y => y.MapFrom(x => x.User.UserName));
        }
    }
}
