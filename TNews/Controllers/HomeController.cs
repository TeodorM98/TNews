using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TNews.Models;

namespace TNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {// Simulated news articles, you can fetch them from a database or external API
            var newsArticles = new List<Article>
        {
            new Article {
                Title = "Breaking News: Something Big Happened",
                Description = "This is a short description of the news article.",
                ImageUrl = "https://via.placeholder.com/150",
                Source = "CNN",
                Url = "https://www.cnn.com",
                PublishedDate = DateTime.Now.AddHours(-1)
            },
            new Article {
                Title = "Tech Update: New Gadgets Announced",
                Description = "This is a short description of the tech news.",
                ImageUrl = "https://via.placeholder.com/150",
                Source = "TechCrunch",
                Url = "https://www.techcrunch.com",
                PublishedDate = DateTime.Now.AddHours(-5)
            },
        };

            return View(newsArticles);
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
