using Store.Interfaces;
using Store.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Helpers
{
    public class DiscountLogic : IDiscountLogic
    {
        public List<Product> DiscountForCategory(List<Product> items, decimal percent)
        {
            foreach (var item in items)
            {
                item.NetUnitPrice = item.NetUnitPrice - (item.NetUnitPrice * percent / 100.00m);
            }

            return items;
        }

        public List<Product> DiscountForProduct(List<Product> items, decimal percent, int selectedProductId)
        {
            foreach (var item in items.Where(q => q.Id == selectedProductId))
            {
                item.NetUnitPrice = item.NetUnitPrice - (item.NetUnitPrice * percent / 100.00m);
            }

            return items;
        }
    }
}