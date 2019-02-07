using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Artists
    {
        [JsonProperty("items")]
        public List<Item> items { get; set; }
    }
}