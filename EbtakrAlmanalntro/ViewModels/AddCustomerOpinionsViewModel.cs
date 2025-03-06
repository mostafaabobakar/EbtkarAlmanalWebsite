using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Models.CustomerOpinionsViewModel
{
    public class AddCustomerOpinionsViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public IFormFile Img { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string DescriptionEn { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public int Rate { get; set; }
        public bool IsActive { get; set; }
    }
}
