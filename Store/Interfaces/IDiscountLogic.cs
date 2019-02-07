using Store.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Interfaces
{
    public interface IDiscountLogic
    {
        List<Product> DiscountForCategory(List<Product> items, decimal percent);

        List<Product> DiscountForProduct(List<Product> items, decimal percent, int selectedProductId);
    }
}