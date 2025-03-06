using Microsoft.AspNetCore.Mvc;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using EbtakrAlmanalntro.Helper;
using EbtakrAlmanalntro.Models.IntroDLLModels;
using System.Collections.Generic;
using System.Linq;

namespace EbtakrAlmanalntro.Controllers
{
    public class EbtakrAlmanalntroController : Controller
    {

        private readonly ApplicationDbContext _context;
        public EbtakrAlmanalntroController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            string lang = "ar";

            IntroSettingViewModel IntroSetting = _context.IntroSettings.Select(x => new IntroSettingViewModel
            {
                LogoImg = x.LogoImg??"",
                Intro = lang == "ar" ? x.IntroAr : x.IntroAr,
                Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                Img = HelperMethods.BaisUrlHoste + x.Img ?? "",
                GooglePlayUrl = x.GooglePlayUrl,
                AppleStoreUrl = x.AppleStoreUrl,
                IntroImg1 = HelperMethods.BaisUrlHoste + x.IntroImg1,
                IntroImg2 = HelperMethods.BaisUrlHoste + x.IntroImg2,
                AboutApp = (lang == "ar" ? x.AboutAppAr : x.AboutAppEn)??"",
                AboutDescrioption = lang == "ar" ? x.AboutDescrioptionAr : x.AboutDescrioptionEn,
                AboutAppImg = HelperMethods.BaisUrlHoste +x.AboutAppImg??"",
                VideoUrl = HelperMethods.BaisUrlHoste + x.VideoUrl,
                FooterDescription = lang == "ar" ? x.FooterDescriptionAr : x.FooterDescriptionEn,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                IsHiddenIntroVideo = x.IsHiddenIntroVideo,
                CommercialRegistrationNo = x.CommercialRegistrationNo,
                TaxNumber = x.TaxNumber,
                licenseNumber = x.licenseNumber,
                conditions = lang == "ar" ? x.TermsOfUsersAr:x.TermsOfUsersEn,
                policy = lang=="ar"? x.PrivacyPolicyAr:x.PrivacyPolicyEn
                

            }).FirstOrDefault();

            List<string> Sliders = _context.AppImgs.Where(x => x.IsActive).Select(x => HelperMethods.BaisUrlHoste + x.Img).ToList();

            List<AdventagesViewModel> Adventages = _context.Advantages.Where(x => x.IsActive).Select(a => new AdventagesViewModel
            {
                Img = a.Img,
                Title = lang == "ar" ? a.TitleAr : a.TitleEn,
                Description = lang == "ar" ? a.DescriptionAr : a.DescriptionEn,
            }).ToList();

            List<CustomerOpinionViewModel> CustomerOpinions = _context.CustomerOpinions.Where(o => o.IsActive).Select(o => new CustomerOpinionViewModel
            {
                Img = o.Img,
                Name = lang == "ar" ? o.NameAr : o.NameEn,
                Description = lang == "ar" ? o.DescriptionAr : o.DescriptionEn,
                Rate = o.Rate
            }).ToList();


            var socialMedia = _context.SocialMedias.Where(x => x.IsActive).ToList();

            var Partners = _context.OurClients.Where(p => !p.IsDeleted && p.IsActive).ToList();


            IntroDLLHomeViewModel model = new IntroDLLHomeViewModel();

            model.IntroSetting = IntroSetting;
            model.Adventages = Adventages;
            model.customerOpinions = CustomerOpinions;
            model.Slider = Sliders;
            model.SocailMedia = socialMedia;
            model.Partners = Partners;

            return View(model);
        }


        public IActionResult Policy()
        {
            string lang = "ar";
            string Policy = _context.IntroSettings.Select(x => lang == "ar" ? x.PrivacyPolicyAr : x.PrivacyPolicyEn).FirstOrDefault();
            ViewBag.Policy = Policy;
            return View();
        }

        public IActionResult Conditions()
        {
            string lang = "ar";
            string Condition = _context.IntroSettings.Select(x => lang == "ar" ? x.TermsOfUsersAr : x.TermsOfUsersEn).FirstOrDefault();
            ViewBag.Condition = Condition;
            return View();

        }
        
        
        public IActionResult Services()
        {
            //ViewBag.Condition = ;
            return View();

        }

        [HttpPost]
        public IActionResult SendMessage(SendMessageViewModel model)
        {
            IntroContactUs contactUs = new IntroContactUs
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Message = model.Msg,
            };

            _context.IntroContactUs.Add(contactUs);
            _context.SaveChanges();

            return Json(new { key = 1, msg = "تم الارسال بنجاح" });
        }

    }
}
