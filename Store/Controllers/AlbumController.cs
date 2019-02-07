using Newtonsoft.Json;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Store.Controllers
{
    public class AlbumController : Controller
    {
        private List<Album> album = new List<Album>
        {
        };
        private StoreContext db = new StoreContext();

        // GET: Album
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string subject = "")
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ArtistNameSortParm = String.IsNullOrEmpty(sortOrder) ? "artist_desc" : "";
            List<Genre> genres = db.Genres.ToList();
            ViewBag.CurrentFilter = genres;

            //auententicacao de usuario
            Spotify spotifyApi = new Spotify();
            //var authenticate = Spotify.Api.AuthenticateWithToken();

            //Metodo para listar albuns por genero atraves do artista (Problema de performance)
            //var model = GetListAlbuns(subject);

            RootObject items = JsonConvert.DeserializeObject<RootObject>(Spotify.Api.GetAlbunsByGenre(subject, "50", "50"));

            var model = items.albums.items;

            model.ForEach(p => { p.price = GetRandomPrice();});
            model.ForEach(p => { p.genre = subject; });

            switch (sortOrder)
            {
                case "name_desc":
                    model = model.OrderBy(s => s.name).ToList();
                    break;
                case "artist_desc":
                    model = model.OrderBy(s => s.Artists.FirstOrDefault().Name).ToList();
                    break;
                case "date_desc":
                    model = model.OrderByDescending(s => s.name).ToList();
                    break;
                default:
                    model = model.OrderBy(s => s.name).ToList();
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        private List<Item> GetListAlbuns(string subject)
        {
            RootObject lstAlbum = new RootObject
            {
                albums = new AlbumRoot
                {
                    items = new List<Item>()
                },
                artists = new Artist {
                    items = new List<Item>()
                },
            };

            RootObject artists = JsonConvert.DeserializeObject<RootObject>(Spotify.Api.GetArtistByGenre(subject, "50", "50"));

            foreach (var artist in artists.artists.items)
            {
                AlbumRoot album = JsonConvert.DeserializeObject<AlbumRoot>(Spotify.Api.GetAlbumByArtist(artist.id));
                lstAlbum.albums.items.Add(album.items.FirstOrDefault());
            }
            return lstAlbum.albums.items;
        }

        public static decimal GetRandomPrice()
        {
            Random r = new Random();
            return r.Next(1, 100);
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
