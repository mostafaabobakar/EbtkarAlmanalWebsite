using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IntroContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntroContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IntroContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.IntroContactUs.ToListAsync());
        }

    }
}
