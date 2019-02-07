using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        //private List<Genre> genre = new List<Genre>
        //{
        //    new Genre {Id= 1, Name = "rock"},
        //    new Genre {Id= 2, Name = "acoustic"},
        //    new Genre {Id= 3, Name = "anime"},
        //    new Genre {Id= 4, Name = "brazil"},
        //    new Genre {Id= 5, Name = "death-metal"},
        //    new Genre {Id= 6, Name = "dance"},

        //};
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            var genre = db.Genres.ToList();
            return View(genre);
        }
    }
}
