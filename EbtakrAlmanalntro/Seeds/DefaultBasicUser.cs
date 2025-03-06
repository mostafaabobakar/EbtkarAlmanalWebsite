using Microsoft.AspNetCore.Identity;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EbtakrAlmanalntro.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationDbUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationDbUser
            {
                UserName = "aait@aait.sa",
                Email = "aait@aait.sa",
                ShowPassword = "123456",

                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123456");
                await userManager.AddToRoleAsync(defaultUser, Enums.AllEnums.Roles.Admin.ToString());
            }
            else
            {
                if (!await userManager.IsInRoleAsync(user, Enums.AllEnums.Roles.Admin.ToString()))
                {
                    await userManager.AddToRoleAsync(user, Enums.AllEnums.Roles.Admin.ToString());
                }
            }


        }
    }
}
