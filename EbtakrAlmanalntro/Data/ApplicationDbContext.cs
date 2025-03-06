using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data.TableDb;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EbtakrAlmanalntro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationDbUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<IntroSetting> IntroSettings { get; set; }
        public DbSet<IntroContactUs> IntroContactUs { get; set; }
        public DbSet<CustomerOpinion> CustomerOpinions { get; set; }
        public DbSet<AppImg> AppImgs { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<OurClient> OurClients { get; set; }
    }
}
