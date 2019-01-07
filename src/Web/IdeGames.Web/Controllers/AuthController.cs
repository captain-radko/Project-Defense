using System;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PusherServer;

namespace IdeGames.Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IdeGamesContext _context;
        private readonly UserManager<IdeGamesUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(IdeGamesContext context
            , UserManager<IdeGamesUser> userManager
            , IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
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
                    Cluster = _configuration["PUSHER_APP_CLUSTER"],
                    Encrypted = true
                };
                var pusher = new Pusher(
                    _configuration["PUSHER_APP_ID"],
                    _configuration["PUSHER_APP_KEY"],
                    _configuration["PUSHER_APP_SECRET"],
                    options
                );

                var auth = pusher.Authenticate(channel_name, socket_id).ToJson();
                return new ContentResult {Content = auth, ContentType = "application/json"};
            }

            return new ContentResult {Content = "Access forbidden", ContentType = "application/json"};
        }
    }
}