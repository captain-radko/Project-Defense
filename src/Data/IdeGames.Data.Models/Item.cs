using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Item : BaseModel<int>
    {
        public Game Game { get; set; }

        public int Quantity { get; set; }
    }
}
