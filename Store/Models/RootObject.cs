using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class RootObject
    {
        public AlbumRoot albums { get; set; }
        public Artist artists { get; set; }
    }
}