using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using EbtakrAlmanalntro.Helper;
using EbtakrAlmanalntro.ViewModels.IntroDLLModels;
using System.Linq;
using System.Threading.Tasks;
using static EbtakrAlmanalntro.Enums.AllEnums;

namespace EbtakrAlmanalntro.Controllers
{
    public class IntroAdvantagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public IntroAdvantagesController(ApplicationDbContext context, IUploadImage uploadImage, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _uploadImage = uploadImage;
            _hostingEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Advantages.ToListAsync());
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAdvantagesViewModel addAdvantagesViewModel)
        {
            if (ModelState.IsValid)
            {
                Advantage customerOpinion = new Advantage
                {
                    TitleAr = addAdvantagesViewModel.TitleAr,
                    TitleEn = addAdvantagesViewModel.TitleEn,

                    DescriptionAr = addAdvantagesViewModel.DescriptionAr,
                    DescriptionEn = addAdvantagesViewModel.DescriptionEn,
                    Img = HelperMethods.ProcessUploadedFile(_hostingEnvironment, addAdvantagesViewModel.Img, FileName.EbtakrAlmanalntro.ToString()),
                    IsActive = true
                };

                _context.Add(customerOpinion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addAdvantagesViewModel);
        }


        // GET: IntroCustomerOpinions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advantage = await _context.Advantages.FindAsync(id);

            if (advantage == null)
            {
                return NotFound();
            }
            EditAdvantagesViewModel model = new EditAdvantagesViewModel()
            {
                DescriptionAr = advantage.DescriptionAr,
                DescriptionEn = advantage.DescriptionEn,
                IsActive = advantage.IsActive,
                Id = advantage.Id,
                ImgPath = advantage.Img,
                TitleAr = advantage.TitleAr,
                TitleEn = advantage.TitleEn,
            };


            return View(model);
        }

        // POST: IntroCustomerOpinions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditAdvantagesViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string img = model.ImgPath;
                    if (model.ImgFormFile != null)
                        img = HelperMethods.ProcessUploadedFile(_hostingEnvironment, model.ImgFormFile, FileName.EbtakrAlmanalntro.ToString());

                    var foundAdvantage = _context.Advantages.Find(model.Id);


                    foundAdvantage.DescriptionAr = model.DescriptionAr;
                    foundAdvantage.DescriptionEn = model.DescriptionEn;
                    foundAdvantage.Img = img;
                    foundAdvantage.IsActive = model.IsActive;
                    foundAdvantage.TitleAr = model.TitleAr;
                    foundAdvantage.TitleEn = model.TitleEn;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvantageExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        private bool AdvantageExists(int id)
        {
            return _context.Advantages.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var advantage = await _context.Advantages.FindAsync(id);

            advantage.IsActive = !advantage.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = advantage.IsActive });
        }


    }
}
