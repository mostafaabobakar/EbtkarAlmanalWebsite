using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Seeds
{
    public static class DefaultSettings
    {
        public static async Task SeedAsync(ApplicationDbContext _context)
        {
            //Seed Default setting
            var getSetting = _context.IntroSettings.FirstOrDefault();
            if (getSetting == null)
            {
                var setting = new IntroSetting
                {
                    Phone = "0123456789",
                    AboutAppAr = ".",
                    AboutAppEn = ".",
                    AboutAppImg = ".",
                    AboutDescrioptionAr = ".",
                    AboutDescrioptionEn = ".",
                    Address = "الرياض _ المملكة العربية السعودية",
                    AppleStoreUrl = "https://www.apple.com",
                    DescriptionAr = ".",
                    DescriptionEn = " .",
                    Email = "aait@aait.sa",
                    FooterDescriptionAr = ".",
                    FooterDescriptionEn = ".",
                    GooglePlayUrl = "https://www.google.com",
                    Img = "",
                    IntroAr = "",
                    IntroEn = "",
                    IntroImg1 = "",
                    IntroImg2 = "",
                    LogoImg = "",
                    PrivacyPolicyAr = "",
                    PrivacyPolicyEn = "",
                    TermsOfUsersAr = "",
                    TermsOfUsersEn = "",
                    VideoUrl = "",
                    CommercialRegistrationNo= "123456789",
                    IsHiddenIntroVideo=false,
                    licenseExpiryDate=DateTime.Now.ToShortDateString(),
                    licenseNumber="123456789",
                    licenseside="",
                    TaxNumber="1234567"
                    

                };

                await _context.IntroSettings.AddAsync(setting);
                await _context.SaveChangesAsync();

            }


        }

    }
}
