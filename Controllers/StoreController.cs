using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusic3.Models;

namespace MvcMusic3.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: Store
        public ActionResult Index()
        {
            //var genres = new List<Genre>
            //{
            //    new Genre { Name = "Disco" },
            //    new Genre { Name = "Jazz" },
            //    new Genre { Name = "Rock" }
            //};

            var genres = storeDB.Genres.ToList();

            return View(genres);
        }

        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string gen)
        {
            //string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            //var genreModel = new Genre { Name = gen };

            // Retrieve Genre and its associated Albums from the database
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == gen);

            return View(genreModel);
        }

        //GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            //var album = new Album { Title = "Album " + id };

            // Retrieve album from db
            var album = storeDB.Albums.Find(id);

            return View(album);
        }
    }
}