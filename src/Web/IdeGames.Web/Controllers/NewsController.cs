using System;
using System.Linq;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.News;
using IdeGames.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class NewsController : BaseController
    {
        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        private readonly INewsService newsService;
        
        public IActionResult Details(int id)
        {
            var news = this.newsService.GetNewsById(id);
            return this.View(news);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var news = this.Db.News.FirstOrDefault(x => x.Id == id);

            if (news == null)
            {
                return this.CustomError(Constants.NullModelError);
            }

            this.Db.Remove(news);

            this.Db.SaveChanges();
            
            return this.Redirect("/Home/Index");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateNewsInputModel model)
        {
            var news = newsService.CreateNews(model);

            this.Db.News.Add(news);

            this.Db.SaveChanges();
            
            return this.RedirectToPage("/Home/Index");
        }
    }
}