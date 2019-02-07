using Microsoft.AspNet.Identity.EntityFramework;
using Store.Interfaces;
using Store.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class StoreContext : IdentityDbContext, IStoreContext
    {
        public StoreContext()
            : base("DefaultConnection")
        {

        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<DiscountModule> DiscountModules { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<Store.Models.Shopping.ShoppingCart> ShoppingCarts { get; set; }
    }
}