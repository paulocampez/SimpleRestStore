using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Shopping
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductId { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Display(Name = "Price")]
        public decimal NetUnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public int Cashback { get; set; }

        public DateTime CreationDate { get; set; }
    }
}