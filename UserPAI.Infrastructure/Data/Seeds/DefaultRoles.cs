using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.CORE.Entities;
using UserAPI.CORE.Model.Enums;

namespace UserAPI.Infrastructure.Data.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync( RoleManager<IdentityRole> roleManager)
        {
            
            await roleManager.CreateAsync(new IdentityRole(Roles.SysAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));
        }
    }
}
