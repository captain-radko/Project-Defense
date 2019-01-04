using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Services.Models.Models.Games
{
    public class CreateGameInputModel : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string  ImageUrl { get; set; }
    }
}