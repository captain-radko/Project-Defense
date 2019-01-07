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
    public class GroupController : BaseController
    {
        private readonly IdeGamesContext _context;
        private readonly UserManager<IdeGamesUser> _userManager;
        private readonly IConfiguration _configuration;

        public GroupController(IdeGamesContext context
            , UserManager<IdeGamesUser> userManager
            , IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<UserGroupViewModel> GetAll()
        {
            var groups = _context.UsersGroups
                .Where(gp => gp.UserName == _userManager.GetUserName(User))
                .Join(_context.Groups, ug => ug.GroupId, g => g.Id, (ug, g) =>
                    new UserGroupViewModel()
                    {
                        UserName = ug.UserName,
                        GroupId = g.Id,
                        GroupName = g.GroupName
                    })
                .ToList();

            return groups;
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewGroupViewModel group)
        {
            if (group == null || group.GroupName == "")
            {
                return new ObjectResult(
                    new {status = "error", message = "incomplete request"}
                );
            }

            if ((_context.Groups.Any(gp => gp.GroupName == group.GroupName)) == true)
            {
                return new ObjectResult(
                    new {status = "error", message = "group name already exist"}
                );
            }

            Group newGroup = new Group {GroupName = group.GroupName};
            // Insert this new group to the database...
            _context.Groups.Add(newGroup);
            _context.SaveChanges();
            //Insert into the user group table, group_id and user_id in the user_groups table...
            foreach (string UserName in group.UserNames)
            {
                _context.UsersGroups.Add(
                    new UserGroup {UserName = UserName, GroupId = newGroup.Id}
                );
                _context.SaveChanges();
            }

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
                "group_chat", //channel name
                "new_group", // event name
                new {newGroup});

            return new ObjectResult(new {status = "success", data = newGroup});
        }
    }
}