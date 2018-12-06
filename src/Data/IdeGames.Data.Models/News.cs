using System;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class News : BaseModel<int>
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public byte[] Image { get; set; }
    }
}
