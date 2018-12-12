using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.Account
{
    public class UserViewModel : BaseModel<string>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
