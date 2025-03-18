using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace EbtakrAlmanalntro.Helper
{
    public static class HelperMethods
    {

        public readonly static string BaisUrlHoste = "https://localhost:44365/";
        //public readonly static string BaisUrlHoste = "http://ebtakralmanal-001-site1.ntempurl.com/";
        //public readonly static string BaisUrlHoste = "https://web.missingboard1.com/";




        #region Roles

        public class AuthorizeRolesAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
        {
            public AuthorizeRolesAttribute(params Enums.AllEnums.Roles[] roles) : base()
            {
                Roles = string.Join(",", roles);
            }

        }


        public static string GetRole(this string role, string lang)
        {
            return role switch
            {
                "AdminBranch" => AAITHelper.HelperMsg.creatMessage(lang, "سوبر ادمن", "AdminBranch"),
                "Admin" => AAITHelper.HelperMsg.creatMessage(lang, "أدمن", "Admin"),
                "Mobile" => AAITHelper.HelperMsg.creatMessage(lang, "موبايل", "Mobile"),

                "Advertisment" => AAITHelper.HelperMsg.creatMessage(lang, "الاعلانات", "Advertisment"),
                "Payments" => AAITHelper.HelperMsg.creatMessage(lang, "الدفع", "Payments"),
                "Copons" => AAITHelper.HelperMsg.creatMessage(lang, "الكوبونات", "Copons"),
                "SocialMedia" => AAITHelper.HelperMsg.creatMessage(lang, "مواقع التواصل الاجتماعى", "SocialMedia"),
                "Questions" => AAITHelper.HelperMsg.creatMessage(lang, "الاسئلة", "Questions"),
                "Notifications" => AAITHelper.HelperMsg.creatMessage(lang, "الاشعارات", "Notifications"),
                "SendSmsMsg" => AAITHelper.HelperMsg.creatMessage(lang, "ارسال رسالة sms", "SendSmsMsg"),
                "Chat" => AAITHelper.HelperMsg.creatMessage(lang, "المحادثات", "Chat"),
                "ContactUs" => AAITHelper.HelperMsg.creatMessage(lang, "الشكاوى والمقترحات", "ContactUs"),
                "Setting" => AAITHelper.HelperMsg.creatMessage(lang, "الاعدادات", "Setting"),

                _ => role
            };
        }

        internal static string ProcessUploadedFile(IWebHostEnvironment hostingEnvironment, IFormFile img, object value)
        {
            throw new NotImplementedException();
        }

        #endregion





        // time now
        [Obsolete]
        public static DateTime TimeNow()
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime currentDate = DateTime.Now;
            DateTime currentUTC = localZone.ToUniversalTime(currentDate);
            return currentUTC.AddHours(3);
        }


        #region Save Image

        public static string ProcessUploadedFile(Microsoft.AspNetCore.Hosting.IWebHostEnvironment HostingEnvironment, Microsoft.AspNetCore.Http.IFormFile Photo = null, string Place = "")
        {
            string uniqueFileName = "Default.png";
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, $"images/{Place}");
                uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Photo.FileName).Replace(" ", string.Empty);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return  $"images/{Place}/" + uniqueFileName;
        }


        #endregion



    }
}
