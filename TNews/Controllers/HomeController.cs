using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TNews.Models;
using TNews.Services;

namespace TNews.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly NewsService _newsService;

        public HomeController(NewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch the articles from the News API service
            var newsArticles = await _newsService.GetNewsAsync();

            return View(newsArticles);  // Pass the articles to the view
        }

        public IActionResult World()
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
    }
}
