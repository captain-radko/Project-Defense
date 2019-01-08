using System;
using IdeGames.Data.Common;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.News
{
    public class NewsDetailsViewModel : BaseModel<int>, IMapFrom<Data.Models.News>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}