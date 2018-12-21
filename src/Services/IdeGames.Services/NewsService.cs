using System;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.News;

namespace IdeGames.Services
{
    public class NewsService : INewsService
    {
        public NewsService()
        {
            this.Db = new IdeGamesContext();
        }

        protected IdeGamesContext Db { get; }

        public NewsDetailsViewModel GetNewsById(int id)
        {
            var news = this.Db.News.Where(x => x.Id == id)
                .Select(x => new NewsDetailsViewModel
                {
                    Name = x.Name,
                    Content = x.Content,
                    PublishedOn = x.PublishedOn
                }).FirstOrDefault();
            return news;
        }

        public News CreateNews(CreateNewsInputModel model)
        {
            var news  = new News
            {
                Id = model.Id,
                Name = model.Name,
                Content = model.Description,
                PublishedOn = model.PublishedOn
            };
            if (news == null)
            {
                throw new ApplicationException("Invalid information provided"); 
            }
            return news;
        }
    }
}