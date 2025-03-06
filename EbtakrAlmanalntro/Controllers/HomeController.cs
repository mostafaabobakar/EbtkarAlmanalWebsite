using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb;
using EbtakrAlmanalntro.Models;
using EbtakrAlmanalntro.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace EbtakrAlmanalntro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationDbUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                HomeViewModel homeViewModel = new HomeViewModel()
                {
                    countContactUs = _context.IntroContactUs.Count(),
                    countCustomerOpinions = _context.CustomerOpinions.Count(),
                    countSocialMedias = _context.SocialMedias.Count()
                };


                return View(homeViewModel);
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
