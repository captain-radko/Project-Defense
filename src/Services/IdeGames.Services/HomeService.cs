using System.Linq;
using IdeGames.Data;
using IdeGames.Services.Contracts;
using IdeGames.Services.Mapping;
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
                .To<NewsViewModel>();
            var model = new IndexViewModel
            {
                News = viewModel
            };

            return model;
        }
    }
}
