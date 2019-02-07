using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Shopping
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public decimal Total { get; set; }

        public decimal TotalDiscout { get; set; }

        public string CartId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual List<CartItem> CartItems { get; set; }

    }
}