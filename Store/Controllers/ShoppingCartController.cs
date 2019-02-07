using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Store.Models;
using Store.Models.Shopping;
using Store.ViewModel;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private StoreContext db = new StoreContext();

        //public ShoppingCartController(StoreContext dbContext)
        //{
        //    db = dbContext;
        //}

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                Total = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(string id, string price, string genre)
        {
            var product = AddProductFromSpotify(id, price, genre);
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            cart.AddToCart(product.Id);

            return RedirectToAction("Index", "Album", new { subject = genre });
        }

        private Product AddProductFromSpotify(string id, string price, string genre)
        {
            //autenticação por usuario
            Spotify spotifyApi = new Spotify();
            //var authenticate = Spotify.Api.AuthenticateWithToken();
            Album album = JsonConvert.DeserializeObject<Album>(Spotify.Api.GetAlbum(id));

            Product product = new Product();
            decimal price2;

            product.ProductName = album.Name;
            product.Genre = genre;
            product.ProductId = album.Id;
            decimal.TryParse(price, out price2);
            product.NetUnitPrice = price2;
            product.CreationDate = DateTime.Now;
            var cashback = Helpers.DayOfWeek.CheckCashbackByDayAndGenre(genre);

            var discount = (price2 * cashback) / 100;
            product.Discount = discount;
            product.Cashback = cashback;

            db.Products.Add(product);
            db.SaveChanges();
            db.Entry(product).GetDatabaseValues();
            return product;
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            cart.RemoveFromCart(id);

            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        public ActionResult CheckDiscounts()
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            cart.CheckDiscounts();

            return View("Index");
        }

        public ActionResult Checkout()
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            Orders checkout = new Orders()
            {
                CartItems = cart.GetCartItems(),
                Total = cart.GetTotal(),
                TotalDiscout = cart.GetTotalDiscout(),
                EndDate = DateTime.Now
            };
            var datetime = checkout.CartItems.OrderBy(p => p.Product.CreationDate).First().Product.CreationDate;

            checkout.CreationDate = datetime;
            db.Orders.Add(checkout);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
