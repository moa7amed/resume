using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Resume.Web.Models;

namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IWebHostEnvironment env, ILogger<HomeController> logger)
        {
            _env = env;
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

        public IActionResult SiteMap()
        {



            try
            {
                // Log entry point
                _logger.LogInformation("Attempting to load the sitemap.");

                // Get the full path to the XML file
                string path = Path.Combine(_env.WebRootPath, "sitemap.xml");

                if (!System.IO.File.Exists(path))
                {
                    _logger.LogWarning($"Sitemap file not found: {path}");
                    return NotFound("Sitemap XML file not found.");
                }

                // Load XML file
                var icon = XDocument.Load(path);

                // Log successful load
                _logger.LogInformation("Sitemap loaded successfully.");

                return Content(icon.ToString(), "text/xml");
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "Error loading sitemap.");

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }


          
        }

        public IActionResult Error()
        {
            return View(); // View should be Views/Home/Error.cshtml
        }






    }
}
