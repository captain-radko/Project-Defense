﻿using System;
using System.Linq;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.News;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var news = this.Db.News.FirstOrDefault(x => x.Id == id);
            
            this.Db.Remove(news ?? throw new InvalidOperationException());

            this.Db.SaveChanges();

            return this.Redirect("/Administration/AdminIndex");
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

            return this.Redirect("/Administration/AdminIndex");
        }
    }
}