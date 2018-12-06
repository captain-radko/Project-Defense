using System.Collections.Generic;
using IdeGames.Services.Models.Models.News;

namespace IdeGames.Services.Models.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }
    }
}