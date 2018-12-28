using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class CartController : BaseController
    {
        public CartController()
        {
            this.Db = new IdeGamesContext();
        }

        public new IdeGamesContext Db { get; set; }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJason<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(i => i.Game.Price * i.Quantity);
            return View();
        }

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