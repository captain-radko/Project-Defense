using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IdeGames.Web.Models;
using IdeGames.Services.Models.Models.Home;

namespace IdeGames.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var viewModel = this.Db.News
                .OrderByDescending(d => d.PublishedOn)
                .Select(x =>
                new NewsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Content = x.Content,
                    PublishedOn = x.PublishedOn
                });
            var model = new IndexViewModel
            {
                News = viewModel
            };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}