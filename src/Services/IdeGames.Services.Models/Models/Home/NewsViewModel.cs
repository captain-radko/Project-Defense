using System;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.Home
{
    public class NewsViewModel : BaseModel<int>
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