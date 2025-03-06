using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb;
using EbtakrAlmanalntro.Helper;
using EbtakrAlmanalntro.ViewModels;
using EbtakrAlmanalntro.ViewModels.IntroDLLModels;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DSocialMediasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment HostingEnvironment;

        public DSocialMediasController(ApplicationDbContext context, IWebHostEnvironment HostingEnvironment)
        {
            _context = context;
            this.HostingEnvironment = HostingEnvironment;
        }

        // GET: DSocialMedias
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialMedias.ToListAsync());
        }


        // GET: DSocialMedias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DSocialMedias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSocialMediaViewModel socialMedia)
        {

            SocialMedia newadvertisement = new SocialMedia
            {
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Img = HelperMethods.ProcessUploadedFile(HostingEnvironment, socialMedia.Img, "EbtakrAlmanalntro"),
                IsActive = true,
            };
            _context.Add(newadvertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: DSocialMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            EditSocialMediaViewModel editSocialMediaViewModel = new EditSocialMediaViewModel
            {
                Id = socialMedia.Id,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Img = socialMedia.Img,
                IsActive = socialMedia.IsActive
            };


            return View(editSocialMediaViewModel);
        }

        // POST: DSocialMedias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSocialMediaViewModel editSocialMediaViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var current = await _context.SocialMedias.FirstOrDefaultAsync(a => a.Id == editSocialMediaViewModel.Id);


                    if (editSocialMediaViewModel.ImgFormFile != null)
                        current.Img = HelperMethods.ProcessUploadedFile(HostingEnvironment, editSocialMediaViewModel.ImgFormFile, "EbtakrAlmanalntro");
                    else
                        current.Img = current.Img;

                    current.Name = editSocialMediaViewModel.Name;
                    current.Url = editSocialMediaViewModel.Url;
                    current.IsActive = editSocialMediaViewModel.IsActive;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaExists(editSocialMediaViewModel.Id))
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
            return View(editSocialMediaViewModel);
        }

        private bool SocialMediaExists(int id)
        {
            return _context.SocialMedias.Any(e => e.Id == id);
        }




        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);

            socialMedia.IsActive = !socialMedia.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = socialMedia.IsActive });
        }
    }
}
