using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Game : BaseModel<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}