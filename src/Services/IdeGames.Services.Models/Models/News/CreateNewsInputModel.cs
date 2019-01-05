using System;
using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Services.Models.Models.News
{
    public class CreateNewsInputModel : BaseModel<int>
    {
        [Required]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(200)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Published On")]
        public DateTime PublishedOn { get; set; }
    }
}