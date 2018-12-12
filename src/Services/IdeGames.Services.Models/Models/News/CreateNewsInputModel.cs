using System;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.News
{
    public class CreateNewsInputModel : BaseModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}
