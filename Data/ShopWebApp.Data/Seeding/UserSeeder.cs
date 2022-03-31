using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopWebApp.Common;
using ShopWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApp.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Users.Any())
            {
                return;
            }

            ApplicationUser admin = new ApplicationUser
            {
                UserName = "Go4ko",
                PasswordHash = "Go4ko%1234567890",
                Email = "georgikostadinov14@abv.bg",
            };

            await userManager.CreateAsync(admin, admin.PasswordHash);
            await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
        }
    }
}
