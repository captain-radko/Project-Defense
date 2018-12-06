using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Home;
using IdeGames.Services.Models.Models.News;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Details(int id)
        {
            var news = this.newsService.GetNewsById(id);
            return this.View(news);
        }
    }
}