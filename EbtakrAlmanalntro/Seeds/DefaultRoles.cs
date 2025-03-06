using Microsoft.AspNetCore.Identity;
using EbtakrAlmanalntro.Data.TableDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationDbUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            foreach (Enums.AllEnums.Roles role in (Enums.AllEnums.Roles[])Enum.GetValues(typeof(Enums.AllEnums.Roles)))
            {
                var ss = await roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }
    }
}
