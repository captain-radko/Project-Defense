using IdeGames.Data.Common;

namespace IdeGames.Services.Models.Models.Chat
{
    public class MessageViewModel : BaseModel<int>
    {
        public string AddedBy { get; set; }

        public string message { get; set; }

        public int GroupId { get; set; }

        public string SocketId { get; set; }
    }
}