using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using EbtakrAlmanalntro.Helper;
using EbtakrAlmanalntro.ViewModels.IntroDLLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Controllers
{
    public class IntroAppImgController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public IntroAppImgController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostEnvironment;
        }

        // GET: IntroCustomerOpinions
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppImgs.ToListAsync());
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAppImgsViewModel model)
        {
            if (ModelState.IsValid)
            {

                List<AppImg> appImgs = new List<AppImg>();

                foreach (var item in model.Img)
                {
                    appImgs.Add(new AppImg()
                    {
                        Img = HelperMethods.ProcessUploadedFile(_hostingEnvironment, item, "EbtakrAlmanalntro"),
                        IsActive = true
                    });
                }
                _context.AppImgs.AddRange(appImgs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var appImg = await _context.AppImgs.FindAsync(id);

            appImg.IsActive = !appImg.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = appImg.IsActive });
        }

    }
}
