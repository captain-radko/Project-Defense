using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;
using IdeGames.Services.Models.Models.Home;

namespace IdeGames.Services.Models.Models.News
{
    public class NewsDetailsViewModel : BaseModel<int>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}