using IdeGames.Data.Models;
using IdeGames.Services.Models.Models.Account;
using IdeGames.Services.Models.Models.Orders;

namespace IdeGames.Services.Contracts
{
    public interface IOrderService
    {
        Order SendOrder(CredentialsInputModel credentials);

        OrdersCollection GetOrders();
    }
}
