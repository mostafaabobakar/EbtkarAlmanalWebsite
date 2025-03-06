using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Models.IntroDLLModels;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Services
{
    public interface IIntroSettingServices
    {
        Task<LayoutIntroDLLViewModel> GetSetting(string lang);
    }

    public class IntroSettingServices : IIntroSettingServices
    {
        private readonly ApplicationDbContext _context;
        public IntroSettingServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LayoutIntroDLLViewModel> GetSetting(string lang = "ar")
        {
            LayoutIntroDLLViewModel model = await _context.IntroSettings.Select(x => new LayoutIntroDLLViewModel
            {
                Intro = lang == "ar" ? x.IntroAr : x.IntroEn,
                Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                FooterDescription = lang == "ar" ? x.FooterDescriptionAr : x.FooterDescriptionEn,
                IntroImg1 = x.IntroImg1,
                IntroImg2 = x.IntroImg2,
                Address = x.Address,
                Email = x.Email,
                //FaceBook = x.FaceBook,
                //Gmail = x.Gmail,
                //Instagram = x.Instagram,
                Logo = x.LogoImg,
                Phone = x.Phone,
                //Twitter = x.Twitter,
                GooglePlayUrl = x.GooglePlayUrl,
                AppleStoreUrl = x.AppleStoreUrl,
                CommercialRegistrationNo = x.CommercialRegistrationNo,
                TaxNumber = x.TaxNumber,
                licenseNumber = x.licenseNumber,
                licenseExpiryDate = x.licenseExpiryDate,
                licenseside = x.licenseside,
            }).FirstOrDefaultAsync();

            return model;
        }
    }

}
