using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeGames.Data;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Account;

namespace IdeGames.Services
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {
            this.Db = new IdeGamesContext();
        }

        public IdeGamesContext Db { get; set; }

        public UserViewModelCollection GetUsers()
        {
            var model = this.Db.Users
                .Select(x => new UserViewModel
                {
                    Id = x.Id.ToString(),
                    FullName = x.FullName,
                    Email = x.Email,
                    RegisteredOn = x.RegisteredOn
                });
            var users = new UserViewModelCollection
            {
                Users = model
            };

            return users;
        }
    }
}
