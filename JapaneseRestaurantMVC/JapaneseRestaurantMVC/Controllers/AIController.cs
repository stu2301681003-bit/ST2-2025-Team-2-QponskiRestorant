using JapaneseRestaurant.Services;
using Microsoft.AspNetCore.Mvc;

namespace JapaneseRestaurant.Controllers
{
    public class AIController : Controller
    {
        private readonly LocalAIModelService _aiService;

        public AIController()
        {
            _aiService = LocalAIModelService.Instance;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetRecommendation(string input)
        {
            ViewBag.Result = string.IsNullOrWhiteSpace(input)
                ? "Please, add text!"
                : _aiService.GenerateRecommendation(input);

            return View("Index");
        }
    }
}
