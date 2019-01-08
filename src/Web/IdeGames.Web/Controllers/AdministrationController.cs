using IdeGames.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class AdministrationController : BaseController
    {
        private readonly IOrderService _orderService;

        public AdministrationController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdminIndex()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult OrdersTable()
        {
            var orders = _orderService.GetOrders();
            return View(orders);
        }
    }
}