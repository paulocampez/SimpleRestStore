using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Shopping
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int IdProduct { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}