using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeGames.Data;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new IdeGamesContext();
        }

        protected IdeGamesContext Db { get; }
    }
}
