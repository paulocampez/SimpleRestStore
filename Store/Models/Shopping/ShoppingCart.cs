using Store.Helpers;
using Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.Shopping
{
    public class ShoppingCart : IShoppingCart
    {

        private readonly IStoreContext _db;
        private readonly string _shoppingCartId;
        IDiscountLogic _discountLogic = new DiscountLogic();

        public ShoppingCart(IStoreContext db, string id)
        {
            _db = db;
            _shoppingCartId = id;
        }

        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "shoppingCartId";

        public static string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }

                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public void AddToCart(int id)
        {
            var product = _db.Products.SingleOrDefault(q => q.Id == id);

            var item = _db.CartItems.SingleOrDefault(q => q.CartId == _shoppingCartId && q.IdProduct == product.Id);

            if (item == null)
            {
                item = new CartItem
                {
                    IdProduct = product.Id,
                    CartId = _shoppingCartId,
                    Quantity = 1,
                };
                _db.CartItems.Add(item);
            }
            else
            {
                item.Quantity++;
            }
            _db.SaveChanges();
        }

        public decimal GetTotalDiscout()
        {
            List<CartItem> items = _db.CartItems.Where(q => q.CartId == _shoppingCartId).ToList();
            List<Product> inCart = new List<Product>();
            decimal total = decimal.Zero;
            foreach (var item in items)
            {
                var product = _db.Products.Where(q => q.Id == item.IdProduct).FirstOrDefault();

                inCart.Add(product);
            }

            foreach (var itemInCart in inCart)
            {
                int amount = items.Where(q => q.IdProduct == itemInCart.Id).Select(q => q.Quantity).FirstOrDefault();
                total = total + itemInCart.Discount.GetValueOrDefault() * amount;
            }

            return total;
        }

        public static ShoppingCart GetCart(StoreContext db, HttpContextBase context)
        => GetCart(db, GetCartId(context));

        public static ShoppingCart GetCart(StoreContext db, string cartId)
            => new ShoppingCart(db, cartId);

        public List<CartItem> GetCartItems()
        {
            var cartItems = _db.CartItems.Where(q => q.CartId == _shoppingCartId).ToList();
            cartItems.ForEach(p =>
            {
                p.Product = _db.Products.Where(x => x.Id == p.IdProduct).Single();

            });
            return cartItems;
        }

        public decimal GetTotal()
        {
            return CheckDiscounts() ?? decimal.Zero;
        }

        public int RemoveFromCart(int id)
        {
            var item = _db.CartItems.SingleOrDefault(q => q.CartId == _shoppingCartId && q.IdProduct == id);

            int itemQuantity = 0;

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                    itemQuantity = item.Quantity;
                }
                else
                {
                    _db.CartItems.Remove(item);
                }
                _db.SaveChanges();
            }

            return itemQuantity;
        }

        public int GetCount()
        {
            int? count = _db.CartItems.Where(q => q.CartId == _shoppingCartId).Select(q => (int?)q.Quantity).Sum();

            return count ?? 0;
        }

        public decimal? CheckDiscounts()
        {
            List<CartItem> items = _db.CartItems.Where(q => q.CartId == _shoppingCartId).ToList();
            List<Discount> discounts = _db.Discounts.ToList();
            List<Product> inCart = new List<Product>();

            decimal total = decimal.Zero;

            foreach (var item in items)
            {
                var product = _db.Products.Where(q => q.Id == item.IdProduct).FirstOrDefault();

                inCart.Add(product);
            }
            
            foreach (var itemInCart in inCart)
            {
                int amount = items.Where(q => q.IdProduct == itemInCart.Id).Select(q => q.Quantity).FirstOrDefault();
                total = total + itemInCart.NetUnitPrice * amount;
            }

            return total;
        }
    }
}