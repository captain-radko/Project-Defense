using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.Games
{
    public class CreateGameInputModel : BaseModel<int>
    {
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string  ImageUrl { get; set; }
    }
}