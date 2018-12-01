using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeGames.Web.Models.Home
{
    public class IndexViewModel : NewsViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }
    }
}
