using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb.IntroductorySite;
using EbtakrAlmanalntro.Helper;
using EbtakrAlmanalntro.ViewModels.IntroSiteModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static EbtakrAlmanalntro.Enums.AllEnums;

namespace EbtakrAlmanalntro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IntroOurClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IntroOurClientsController(ApplicationDbContext context, IUploadImage uploadImage, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _uploadImage = uploadImage;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var ourClients = await _context.OurClients.Where(c => !c.IsDeleted).ToListAsync();
            return View(ourClients);
        }



        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] AddOurClientViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            var files = Request.Form.Files;
            if (!files.Any())
            {
                ModelState.AddModelError("Image", "من فضلك قم باختيار صورة.");
                return View(model);
            }

            var img = files.FirstOrDefault();
            var allowedExtensions = new List<string> { ".jpg", ".png", ".jpeg" };
            if (!allowedExtensions.Contains(Path.GetExtension(img.FileName).ToLower()))
            {
                ModelState.AddModelError("Image", "غير مسموح سوي بالامتدادت التالية: JPG، PNG");
                return View(model);
            }
            
            if(img.Length > 3145728)
            {
                ModelState.AddModelError("Image", "لا يمكنك رفع صورة حجمها اكبر من 3 ميجابايت");
                return View(model);
            }

            var ourClient = new OurClient
            {
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                DescriptionAr = model.DescriptionAr,
                DescriptionEn = model.DescriptionEn,
                ImageUrl = HelperMethods.ProcessUploadedFile(_hostingEnvironment, model.Image, FileName.EbtakrAlmanalntro.ToString()),
                IsActive  = true
            };
            await _context.OurClients.AddAsync(ourClient);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var client = await _context.OurClients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            EditOurClientViewModel model = new EditOurClientViewModel
            {
                ID = client.ID,
                NameAr = client.NameAr,
                NameEn = client.NameEn,
                DescriptionAr = client.DescriptionAr,
                DescriptionEn = client.DescriptionEn,
                IsActive = client.IsActive,
                ImageUrl = client.ImageUrl,
            };


            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] EditOurClientViewModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var client = _context.OurClients.Find(model.ID);

                    var files = Request.Form.Files;
                    if(files.Count == 1)
                    {
                        var img = files.FirstOrDefault();
                        var allowedExtensions = new List<string> { ".jpg", ".png" };
                        if (!allowedExtensions.Contains(Path.GetExtension(img.FileName).ToLower()))
                        {
                            ModelState.AddModelError("Image", "غير مسموح سوي بالامتدادت التالية: JPG، PNG");
                            return View(model);
                        }

                        if (img.Length > 3145728)
                        {
                            ModelState.AddModelError("Image", "لا يمكنك رفع صورة حجمها اكبر من 3 ميجابايت");
                            return View(model);
                        }
                        client.ImageUrl = model.Image is not null ? HelperMethods.ProcessUploadedFile(_hostingEnvironment, model.Image, FileName.EbtakrAlmanalntro.ToString()) : client.ImageUrl;
                    }

                    client.NameAr = model.NameAr;
                    client.NameEn = model.NameEn;
                    client.DescriptionAr = model.DescriptionAr;
                    client.DescriptionEn = model.DescriptionEn;

                    client.IsActive = model.IsActive;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(model.ID))
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



        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return Json(new { key = 0, Msg = "رقم تعريفي خاطئ" });

            var client = await _context.OurClients.FindAsync(id);

            if (client is null)
                return Json(new { key = 0, Msg = "لا يوجد عميل ملحق بهذا الرقم التعريفي" });

            client.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = client.IsDeleted });
        }





        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            if (id is null)
                return Json(new { key = 0, Msg = "رقم تعريفي خاطئ" });

            var client = await _context.OurClients.FindAsync(id);

            if (client is null)
                return Json(new { key = 0, Msg = "لا يوجد عميل ملحق بهذا الرقم التعريفي" });

            client.IsActive = !client.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = client.IsActive });
        }




        private bool ClientExists(int id)
        {
            return _context.OurClients.Any(c => c.ID == id);
        }


    }
}



