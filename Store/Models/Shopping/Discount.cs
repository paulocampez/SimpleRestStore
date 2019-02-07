using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Shopping
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        public int DiscountModuleId { get; set; }

        public int? ProductId { get; set; }

        public int? CategoryId { get; set; }

        public int ItemQuantity { get; set; }

        public decimal DiscountPercentage { get; set; }

        public virtual Product Product { get; set; }

        public virtual DiscountModule DiscountModule { get; set; }

        public virtual Category Category { get; set; }

    }
}