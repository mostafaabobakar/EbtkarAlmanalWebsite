using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.ViewModels
{
    public class EditSocialMediaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string Img { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public IFormFile ImgFormFile { get; set; }
    }
}
