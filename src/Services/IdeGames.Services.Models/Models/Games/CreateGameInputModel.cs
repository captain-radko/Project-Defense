using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.Games
{
    public class CreateGameInputModel : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }
    }
}