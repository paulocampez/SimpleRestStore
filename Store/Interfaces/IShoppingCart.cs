using Store.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Interfaces
{
    public interface IShoppingCart
    {

        void AddToCart(int id);

        List<CartItem> GetCartItems();

        decimal GetTotal();

        int RemoveFromCart(int id);

        int GetCount();

        decimal? CheckDiscounts();
    }
}