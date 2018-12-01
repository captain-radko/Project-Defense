﻿using System;

namespace IdeGames.Web.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}