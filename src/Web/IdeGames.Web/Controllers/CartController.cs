using System.Collections.Generic;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Account;
using IdeGames.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly IOrderService _orderService;

        public CartController(IOrderService orderService)
        {
            _orderService = orderService;
            this.Db = new IdeGamesContext();
        }

        public new IdeGamesContext Db { get; set; }

        [Authorize]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJason<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(i => i.Game.Price * i.Quantity);
            }
            else
            {
                return Redirect("/Games/Index");
            }
            return View();
        }

        [Authorize]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJason<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>
                {
                    new Item()
                    {
                        Game = this.Db.Games.Find(id),
                        Quantity = 1
                    }
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJason<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        Game = this.Db.Games.Find(id),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return this.RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var cart = SessionHelper.GetObjectFromJason<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = SessionHelper.GetObjectFromJason<List<Item>>(HttpContext.Session, "cart");
            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("FinalizeOrder");
        }

        [Authorize]
        public IActionResult FinalizeOrder()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult FinalizeOrder(CredentialsInputModel credentials)
        {
            var order = _orderService.SendOrder(credentials);

            this.Db.Add(order);

            this.Db.SaveChanges();

            return this.Redirect("/Home/Index");
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Game.Id == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}