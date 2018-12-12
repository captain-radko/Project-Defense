using IdeGames.Services.Models.Models.Account;

namespace IdeGames.Services.Contracts
{
    public interface IAccountService
    {
        UserViewModelCollection GetUsers();
    }
}
