﻿using System.Collections.Generic;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Game : BaseModel<int>
    {
        public Game()
        {
            Comment = new HashSet<Comment>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                if (this.Description?.Length > 310)
                {
                    return this.Description.Substring(0, 310) + "...";
                }
                else
                {
                    return this.Description;
                }
            }
        }

        public byte[] Image { get; set; }

        public ICollection<Comment> Comment { get; set; }
    }
}