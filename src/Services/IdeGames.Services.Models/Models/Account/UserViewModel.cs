using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.Account
{
    public class UserViewModel : BaseModel<string>
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
