using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using EbtakrAlmanalntro.Helper;
using EbtakrAlmanalntro.Models.CustomerOpinionsViewModel;
using EbtakrAlmanalntro.ViewModels.IntroDLLModels;
using System.Linq;
using System.Threading.Tasks;
using static EbtakrAlmanalntro.Enums.AllEnums;

namespace EbtakrAlmanalntro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IntroCustomerOpinionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public IntroCustomerOpinionsController(ApplicationDbContext context, IUploadImage uploadImage, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _uploadImage = uploadImage;
            _hostingEnvironment = hostEnvironment;
        }

        // GET: IntroCustomerOpinions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerOpinions.ToListAsync());
        }


        // GET: IntroCustomerOpinions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IntroCustomerOpinions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddCustomerOpinionsViewModel addCustomerOpinionsViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomerOpinion customerOpinion = new CustomerOpinion
                {
                    NameAr = addCustomerOpinionsViewModel.NameAr,
                    NameEn = addCustomerOpinionsViewModel.NameEn,
                    DescriptionAr = addCustomerOpinionsViewModel.DescriptionAr,
                    DescriptionEn = addCustomerOpinionsViewModel.DescriptionEn,
                    Rate = addCustomerOpinionsViewModel.Rate,
                    Img = HelperMethods.ProcessUploadedFile(_hostingEnvironment, addCustomerOpinionsViewModel.Img, FileName.EbtakrAlmanalntro.ToString()),
                    IsActive = true
                };

                _context.Add(customerOpinion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addCustomerOpinionsViewModel);
        }

        // GET: IntroCustomerOpinions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOpinion = await _context.CustomerOpinions.FindAsync(id);

            if (customerOpinion == null)
            {
                return NotFound();
            }
            EditCustomerOpinionsViewModel editCustomerOpinionsViewModel = new EditCustomerOpinionsViewModel()
            {
                DescriptionAr = customerOpinion.DescriptionAr,
                DescriptionEn = customerOpinion.DescriptionEn,
                IsActive = customerOpinion.IsActive,
                Id = customerOpinion.Id,
                ImgPath = customerOpinion.Img,
                NameAr = customerOpinion.NameAr,
                NameEn = customerOpinion.NameEn,
                Rate = customerOpinion.Rate,
            };


            return View(editCustomerOpinionsViewModel);
        }

        // POST: IntroCustomerOpinions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCustomerOpinionsViewModel model)
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
                    if (model.Img != null)
                        img = HelperMethods.ProcessUploadedFile(_hostingEnvironment, model.Img, FileName.EbtakrAlmanalntro.ToString());

                    var foundCustomerOpinion = _context.CustomerOpinions.Find(model.Id);


                    foundCustomerOpinion.DescriptionAr = model.DescriptionAr;
                    foundCustomerOpinion.DescriptionEn = model.DescriptionEn;
                    foundCustomerOpinion.Img = img;
                    foundCustomerOpinion.IsActive = model.IsActive;
                    foundCustomerOpinion.NameAr = model.NameAr;
                    foundCustomerOpinion.NameEn = model.NameEn;
                    foundCustomerOpinion.Rate = model.Rate;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerOpinionExists(model.Id))
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



        private bool CustomerOpinionExists(int id)
        {
            return _context.CustomerOpinions.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var customerOpinion = await _context.CustomerOpinions.FindAsync(id);

            customerOpinion.IsActive = !customerOpinion.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = customerOpinion.IsActive });
        }



    }
}
