using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EbtakrAlmanalntro.ViewModels.IntroSiteModels
{
    public class EditOurClientViewModel
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string NameAr { get; set; }


        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string NameEn { get; set; }


        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string DescriptionAr { get; set; }


        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string DescriptionEn { get; set; }


        public IFormFile Image { get; set; }


        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public bool IsActive { get; set; }
    }
}
