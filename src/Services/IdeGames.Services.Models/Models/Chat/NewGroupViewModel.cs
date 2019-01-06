using System.Collections.Generic;

namespace IdeGames.Services.Models.Models.Chat
{
    public class NewGroupViewModel
    {
        public string GroupName { get; set; }

        public List<string> UserNames { get; set; }
    }
}