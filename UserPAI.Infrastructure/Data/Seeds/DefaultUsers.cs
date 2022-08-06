using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;
using UserAPI.CORE.Model;
using UserAPI.CORE.Model.Enums;

namespace UserAPI.Infrastructure.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedCustomerAsync(WebAppContext webAppContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            var defaultUser = new User
            {
                UserName = "basicuser@gmail.com",
                Email = "basicuser@gmail.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Email != defaultUser.Email))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var createPowerUser = await userManager.CreateAsync(defaultUser, "123@abC");
                    if (createPowerUser.Succeeded)
                        userManager.AddToRoleAsync(defaultUser, Roles.Customer.ToString()).GetAwaiter().GetResult();
                }
            }


        }
        public static async Task SeedSuperAdminAsync(WebAppContext webAppContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            var defaultUser = new User
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Email != defaultUser.Email))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var createPowerUser = await userManager.CreateAsync(defaultUser, "123@abC");
                    if (createPowerUser.Succeeded)
                        userManager.AddToRoleAsync(defaultUser, Roles.SysAdmin.ToString()).GetAwaiter().GetResult();
                }

            }



        }
        public static async Task SeedAdminAsync(WebAppContext webAppContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {


            var defaultUser = new User
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                BrandId = 1
            };



            if (userManager.Users.All(u => u.Email != defaultUser.Email))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var createPowerUser = await userManager.CreateAsync(defaultUser, "123@abC");
                    if (createPowerUser.Succeeded)
                        userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString()).GetAwaiter().GetResult();
                }

            }



        }

    }
}
