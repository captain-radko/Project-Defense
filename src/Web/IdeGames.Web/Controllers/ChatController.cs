using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Models.Models.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    [Authorize]
    public class ChatController : BaseController
    {
        private readonly UserManager<IdeGamesUser> _userManager;
        private readonly IdeGamesContext _groupContext;

        public ChatController(
            UserManager<IdeGamesUser> userManager,
            IdeGamesContext context
        )
        {
            _userManager = userManager;
            _groupContext = context;
        }

        public IActionResult Index()
        {
            var groups = _groupContext.UsersGroups
                .Where(gp => gp.UserName == _userManager.GetUserName(User))
                .Join(_groupContext.Groups, ug => ug.GroupId, g => g.Id, (ug, g) =>
                    new UserGroupViewModel
                    {
                        UserName = ug.UserName,
                        GroupId = g.Id,
                        GroupName = g.GroupName
                    })
                .ToList();

            ViewData["UserGroups"] = groups;

            // get all users      
            ViewData["Users"] = _userManager.Users;
            return View();
        }
    }
}