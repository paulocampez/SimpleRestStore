using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Shopping
{
    public class DiscountModule
    {
        [Key]
        public int DiscountModuleId { get; set; }

        public int DiscountModuleNumber { get; set; }

        public string DiscountDescription { get; set; }

    }
}