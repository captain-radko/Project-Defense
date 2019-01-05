using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class UserGroup : BaseModel<int>
    {
        public string UserName { get; set;  }

        public int GroupId { get; set;  }
    }
}
