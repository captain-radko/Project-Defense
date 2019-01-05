using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Data.Models
{
    public class Group : BaseModel<int>
    {
        public string GroupName { get; set; }
    }
}