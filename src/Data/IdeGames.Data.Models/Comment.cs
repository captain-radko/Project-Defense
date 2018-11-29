using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Comment : BaseModel<int>
    {
        public IdeGamesUser Author { get; set; }
    }
}