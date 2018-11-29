using System;
using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;

namespace IdeGames.Data.Models
{
    // Add profile data for application users by adding properties to the IdeGamesUser class
    public class IdeGamesUser : IdentityUser
    {
        public IdeGamesUser()
        {
            this.Games = new HashSet<Game>();
            this.Comments = new List<Comment>();
        }

        public string FullName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public ICollection<Game> Games { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}