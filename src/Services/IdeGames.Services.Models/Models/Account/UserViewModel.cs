using System;
using System.ComponentModel.DataAnnotations;
using IdeGames.Data.Common;
using IdeGames.Data.Models;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Account
{
    public class UserViewModel : BaseModel<string>, IMapFrom<IdeGamesUser>
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
