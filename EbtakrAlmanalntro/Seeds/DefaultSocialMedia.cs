using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Seeds
{
    public static class DefaultSocialMedia
    {
        public static async Task SeedAsync(ApplicationDbContext _context)
        {
            //Seed Default social
            var getsocials = _context.SocialMedias;
            if (getsocials.Count() == 0)
            {

                List<SocialMedia> socials = new List<SocialMedia>
                {
                    new SocialMedia
                    {
                        Img = "https://upload.wikimedia.org/wikipedia/commons/0/05/Facebook_Logo_%282019%29.png",
                        Name = "FaceBook",
                        Url="https://www.facebook.com/",
                        IsActive = true

                    },
                     new SocialMedia
                    {
                        Img = "https://cdn.icon-icons.com/icons2/2157/PNG/512/twitter_logo_icon_132881.png",
                        Name = "Twitter",
                        Url="https://twitter.com/",
                        IsActive = true

                    },
                };

                await _context.SocialMedias.AddRangeAsync(socials);
                await _context.SaveChangesAsync();

            }
        }
    }
}
