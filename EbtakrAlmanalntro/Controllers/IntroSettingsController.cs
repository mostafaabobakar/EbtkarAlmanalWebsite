using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using EbtakrAlmanalntro.Helper;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Controllers
{
    [Authorize(Roles = "Admin")]

    public class IntroSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IntroSettingsController(ApplicationDbContext context, IUploadImage uploadImage, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _uploadImage = uploadImage;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: IntroSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var introSetting = await _context.IntroSettings.FirstOrDefaultAsync();
            if (introSetting == null)
            {
                return NotFound();
            }
            return View(introSetting);
        }

        public class IntroSettingImgageDTO
        {
            public IFormFile LogoImgFormFile { get; set; }
            public IFormFile IntroImg1FormFile { get; set; }
            public IFormFile IntroImg2FormFile { get; set; }
            public IFormFile AboutAppImgFormFile { get; set; }
            public IFormFile VideoUrlFormFile { get; set; }
        }
        // POST: IntroSettings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IntroSetting introSetting, IntroSettingImgageDTO introSettingImgageDTO)
        {

            if (ModelState.IsValid)
            {
                IntroSetting oldIntroSetting = await _context.IntroSettings.FirstOrDefaultAsync();

                oldIntroSetting.LogoImg = introSettingImgageDTO.LogoImgFormFile != null ? HelperMethods.ProcessUploadedFile(_hostingEnvironment, introSettingImgageDTO.LogoImgFormFile, "EbtakrAlmanalntro") : oldIntroSetting.LogoImg;
                oldIntroSetting.IntroImg1 = introSettingImgageDTO.IntroImg1FormFile != null ? HelperMethods.ProcessUploadedFile(_hostingEnvironment, introSettingImgageDTO.IntroImg1FormFile, "EbtakrAlmanalntro") : oldIntroSetting.IntroImg1;
                oldIntroSetting.IntroImg2 = introSettingImgageDTO.IntroImg2FormFile != null ? HelperMethods.ProcessUploadedFile(_hostingEnvironment, introSettingImgageDTO.IntroImg2FormFile, "EbtakrAlmanalntro") : oldIntroSetting.IntroImg2;
                oldIntroSetting.AboutAppImg = introSettingImgageDTO.AboutAppImgFormFile != null ? HelperMethods.ProcessUploadedFile(_hostingEnvironment, introSettingImgageDTO.AboutAppImgFormFile, "EbtakrAlmanalntro") : oldIntroSetting.AboutAppImg;
                oldIntroSetting.VideoUrl = introSettingImgageDTO.VideoUrlFormFile != null ? HelperMethods.ProcessUploadedFile(_hostingEnvironment, introSettingImgageDTO.VideoUrlFormFile, "EbtakrAlmanalntro") : oldIntroSetting.VideoUrl;

                // oldIntroSetting.Id = introSetting.Id;

                oldIntroSetting.IntroAr = introSetting.IntroAr;
                oldIntroSetting.IntroEn = introSetting.IntroAr;
                oldIntroSetting.DescriptionAr = introSetting.DescriptionAr;
                oldIntroSetting.DescriptionEn = introSetting.DescriptionAr;

                oldIntroSetting.GooglePlayUrl = introSetting.GooglePlayUrl;
                oldIntroSetting.AppleStoreUrl = introSetting.AppleStoreUrl;

                oldIntroSetting.AboutDescrioptionAr = introSetting.AboutDescrioptionAr;
                oldIntroSetting.AboutDescrioptionEn = introSetting.AboutDescrioptionAr;
                oldIntroSetting.FooterDescriptionAr = introSetting.FooterDescriptionAr;
                oldIntroSetting.FooterDescriptionEn = introSetting.FooterDescriptionAr;

                oldIntroSetting.Address = introSetting.Address;
                oldIntroSetting.Phone = introSetting.Phone;
                oldIntroSetting.Email = introSetting.Email;
                oldIntroSetting.CommercialRegistrationNo = introSetting.CommercialRegistrationNo;
                oldIntroSetting.TaxNumber = introSetting.TaxNumber;
                oldIntroSetting.licenseNumber = introSetting.licenseNumber;
                //oldIntroSetting.licenseExpiryDate = introSetting.licenseExpiryDate;
                oldIntroSetting.licenseside = introSetting.licenseside;


                oldIntroSetting.PrivacyPolicyAr = introSetting.PrivacyPolicyAr;
                oldIntroSetting.PrivacyPolicyEn = introSetting.PrivacyPolicyAr;
                oldIntroSetting.TermsOfUsersAr = introSetting.TermsOfUsersAr;
                oldIntroSetting.TermsOfUsersEn = introSetting.TermsOfUsersAr;
                oldIntroSetting.IsHiddenIntroVideo = introSetting.IsHiddenIntroVideo;
                oldIntroSetting.AboutAppAr = introSetting.AboutAppAr;
                oldIntroSetting.AboutAppEn = introSetting.AboutAppAr;
                try
                {
                    // _context.Update(oldIntroSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntroSettingExists(introSetting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index", "Home");
            }
            return View(introSetting);
        }
        private bool IntroSettingExists(int id)
        {
            return _context.IntroSettings.Any(e => e.Id == id);
        }
    }
}
