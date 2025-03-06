using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.ViewModels.IntroDLLModels
{
    public class EditAdvantagesViewModel
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public IFormFile ImgFormFile { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string TitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string DescriptionEn { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public bool IsActive { get; set; }
    }
}
