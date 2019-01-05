using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Message : BaseModel<int>
    {
        public string AddedBy { get; set;  }

        public string message { get; set;  }

        public int GroupId { get; set;  }
    }
}
