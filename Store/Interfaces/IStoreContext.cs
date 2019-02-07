using Store.Models;
using Store.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Store.Interfaces
{
    public interface IStoreContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<DiscountModule> DiscountModules { get; set; }

        int SaveChanges();

        Database Database { get; }
    }
}