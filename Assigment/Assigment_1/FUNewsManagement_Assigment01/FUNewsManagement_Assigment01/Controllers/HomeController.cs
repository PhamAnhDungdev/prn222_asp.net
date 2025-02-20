using FUNewsManagement_Assigment01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FUNewsManagement_Assigment01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FunewsManagementContext _context;
        public HomeController(ILogger<HomeController> logger, FunewsManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            var newsArticle = _context.NewsArticles
                .Include(n => n.Category)
                .ToList();
            ViewBag.Category = category;
            ViewBag.NewsArticles = newsArticle;
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
