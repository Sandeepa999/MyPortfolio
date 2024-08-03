using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Web.Models;
using System.Diagnostics;

namespace MyPortfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult DownloadPDF()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "cv.pdf");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = "cv.pdf";

            return File(fileBytes, "application/pdf", fileName);
        }
    }
}
