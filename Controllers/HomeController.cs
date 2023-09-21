using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;  // DbContext için bir alan

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)  // ApplicationDbContext'yi inject et
        {
            _logger = logger;
            _context = context;  // DbContext için alanı ayarla
        }

        public async Task<IActionResult> Index()
        {
            // iller tablosundan tüm şehirleri çek
            List<Il> iller = await _context.iller.ToListAsync();

            // Şehirleri ViewBag ile View'a taşı
            ViewBag.Iller = iller;

            return View();
        }


        public async Task<IActionResult> GetIlceler(int sehirId)
        {
            var ilceler = await _context.ilceler.Where(i => i.sehirid == sehirId).ToListAsync();
            return Json(ilceler);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
