using System;
using IdeGames.Data.Common;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Home
{
    using IdeGames.Data.Models;

    public class NewsViewModel : BaseModel<int>, IMapFrom<News>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                if (this.Content?.Length > 310)
                {
                    return this.Content.Substring(0, 310) + "...";
                }
                else
                {
                    return this.Content;
                }
            }
        }

        public DateTime PublishedOn { get; set; }
    }
}