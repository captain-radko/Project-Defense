﻿using System;
using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.News
{
    public class CreateNewsInputModel : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }
    }
}