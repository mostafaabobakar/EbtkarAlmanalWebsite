using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Data.TableDb.IntroductorySite
{
    public class IntroSetting
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Section Intro
        /// </summary>
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string IntroAr { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string IntroEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescriptionAr { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescriptionEn { get; set; }

        public string LogoImg { get; set; }
        public string Img { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string GooglePlayUrl { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AppleStoreUrl { get; set; }
        public string IntroImg1 { get; set; }
        public string IntroImg2 { get; set; }

        /// <summary>
        /// Section About App
        /// </summary>
        //[Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string AboutAppAr { get; set; }
        //[Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string AboutAppEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutDescrioptionAr { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutDescrioptionEn { get; set; }
        public string AboutAppImg { get; set; }

        /// <summary>
        /// Section Video
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Section Footer
        /// </summary>
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FooterDescriptionAr { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FooterDescriptionEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Address { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Email { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CommercialRegistrationNo { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string TaxNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string licenseNumber { get; set; }
        public string licenseExpiryDate { get; set; }
        public string licenseside { get; set; }
        //public string FaceBook { get; set; }
        //[Required(ErrorMessage ="هذا الحقل مطلوب")]
        //public string Twitter { get; set; }
        //[Required(ErrorMessage ="هذا الحقل مطلوب")]
        //public string Instagram { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        //public string Gmail { get; set; }

        /// <summary>
        /// Section Two Pages
        /// </summary>
        [Required(ErrorMessage = "هذا الحقل مطلوب")]

        public string PrivacyPolicyAr { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]

        public string PrivacyPolicyEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]

        public string TermsOfUsersAr { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]

        public string TermsOfUsersEn { get; set; }

        public bool IsHiddenIntroVideo { get; set; }

    }
}
