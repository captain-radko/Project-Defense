using System.Collections.Generic;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Models.Models.Chat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PusherServer;

namespace IdeGames.Web.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : BaseController
    {
        private readonly IdeGamesContext _context;
        private readonly UserManager<IdeGamesUser> _userManager;
        private readonly IConfiguration _configuration;

        public MessageController(IdeGamesContext context
            , UserManager<IdeGamesUser> userManager
            , IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet("{group_id}")]
        public IEnumerable<Message> GetById(int group_id)
        {
            return _context.Messages.Where(gb => gb.GroupId == group_id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MessageViewModel message)
        {
            Message new_message = new Message
                {AddedBy = _userManager.GetUserName(User), message = message.message, GroupId = message.GroupId};

            _context.Messages.Add(new_message);
            _context.SaveChanges();

            var options = new PusherOptions
            {
                Cluster = _configuration["PUSHER_APP_CLUSTER"],
                Encrypted = true
            };
            var pusher = new Pusher(
                _configuration["PUSHER_APP_ID"],
                _configuration["PUSHER_APP_KEY"],
                _configuration["PUSHER_APP_SECRET"],
                options
            );
            var result = pusher.TriggerAsync(
                "private-" + message.GroupId,
                "new_message",
                new {new_message},
                new TriggerOptions() {SocketId = message.SocketId});

            return new ObjectResult(new {status = "success", data = new_message});
        }
    }
}