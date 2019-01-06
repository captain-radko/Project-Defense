using System;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace IdeGames.Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IdeGamesContext _context;
        private readonly UserManager<IdeGamesUser> _userManager;

        public AuthController(IdeGamesContext context, UserManager<IdeGamesUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult ChannelAuth(string channel_name, string socket_id)
        {
            int group_id;
            if (!User.Identity.IsAuthenticated)
            {
                return new ContentResult {Content = "Access forbidden", ContentType = "application/json"};
            }

            try
            {
                group_id = Int32.Parse(channel_name.Replace("private-", ""));
            }
            catch (FormatException e)
            {
                return Json(new {Content = e.Message});
            }

            int IsInChannel = _context.UsersGroups
                .Count(gb => gb.GroupId == group_id
                             && gb.UserName == _userManager.GetUserName(User));

            if (IsInChannel > 0)
            {
                var options = new PusherOptions
                {
                    Cluster = "eu",
                    Encrypted = true
                };
                var pusher = new Pusher(
                    "685221",
                    "6253f66941faa2dad217",
                    "8780cdd3d95f6032e1dd",
                    options
                );

                var auth = pusher.Authenticate(channel_name, socket_id).ToJson();
                return new ContentResult {Content = auth, ContentType = "application/json"};
            }

            return new ContentResult {Content = "Access forbidden", ContentType = "application/json"};
        }
    }
}