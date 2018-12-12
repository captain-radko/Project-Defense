using System.Linq;
using IdeGames.Data;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Home;

namespace IdeGames.Services
{
    public class HomeService : IHomeService
    {
        public HomeService()
        {
            this.Db = new IdeGamesContext();
        }

        public IdeGamesContext Db { get; set; }

        public IndexViewModel GetNews()
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

            return model;
        }
    }
}
