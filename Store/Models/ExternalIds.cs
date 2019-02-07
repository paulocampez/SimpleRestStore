using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class ExternalIds
    {
        [JsonProperty(PropertyName = "upc")]
        public string Upc { get; set; }
    }
}