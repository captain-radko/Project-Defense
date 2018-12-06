using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;
using IdeGames.Data.Models;

namespace IdeGames.Services.Models.Models.Games
{
    public class GamesViewModel : BaseModel<int>
    {
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

        public ICollection<Comment> Comments { get; set; }
    }
}
