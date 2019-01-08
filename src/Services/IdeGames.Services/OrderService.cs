using System;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Contracts;
using IdeGames.Services.Mapping;
using IdeGames.Services.Models.Models.Account;
using IdeGames.Services.Models.Models.Orders;

namespace IdeGames.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
            this.Db = new IdeGamesContext();
        }

        protected IdeGamesContext Db { get; }

        public Order SendOrder(CredentialsInputModel credentials)
        {
            var order = new Order
            {
                Name = credentials.Name,
                Email = credentials.Email,
                PhoneNumber = credentials.PhoneNumber,
                Address = credentials.Address,
                OrderOn = DateTime.Now
            };
            return order;
        }

        public OrdersCollection GetOrders()
        {
            var model = this.Db.Orders.To<OrdersTable>();

            var order = new OrdersCollection
            {
                Orders = model
            };
            return order;
        }
    }
}