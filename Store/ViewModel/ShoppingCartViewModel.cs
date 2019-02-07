using Store.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }
    }
}