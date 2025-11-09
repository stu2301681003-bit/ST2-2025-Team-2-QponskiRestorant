using JapaneseRestaurant.Services;
using JapaneseRestaurantMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JapaneseRestaurantMVC.Controllers
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
            var aiService = LocalAIModelService.Instance;
            var recommendation = aiService.GenerateRecommendation("Sushi");

            ViewBag.Recommendation = recommendation;

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
    }
}
