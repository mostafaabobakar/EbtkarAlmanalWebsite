using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.ViewModels.IntroDLLModels
{
    public class AddAppImgsViewModel
    {
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public List<IFormFile> Img { get; set; }
    }
}
