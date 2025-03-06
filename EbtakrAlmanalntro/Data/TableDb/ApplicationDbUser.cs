using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Data.TableDb
{
    // Add profile data for application users by adding properties to the ApplicationDbUser class
    public class ApplicationDbUser : IdentityUser
    {
        public string ShowPassword { get; set; }
    }
}
