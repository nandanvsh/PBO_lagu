using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lagu.Entity;

namespace lagu.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        // GET: Menus
        public ActionResult Index()
        {
            List<Genre> m;
            using (var r = new GenreEntities())
            {
                m = r.Genres.ToList();
            }
            return View(m);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var genremodel = new Genre();
            TryUpdateModel(genremodel);

            using (var r = new GenreEntities())
            {
                r.Genres.Add(genremodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menumodel = new Genre();
            TryUpdateModel(menumodel);

            using (var r = new GenreEntities())
            {
                menumodel = r.Genres.FirstOrDefault(x => x.id_genre_ == id);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            var menumodel = new Genre();
            TryUpdateModel(menumodel);

            using (var r = new GenreEntities())
            {
                menumodel = r.Genres.FirstOrDefault(x => x.id_genre_ == id);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            var menumodel = new Genre();
            TryUpdateModel(menumodel);

            using (var r = new GenreEntities())
            {
                var m = r.Genres.Where(x => x.id_genre_ == id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            var menumodel = new Genre();
            TryUpdateModel(menumodel);

            using (var r = new GenreEntities())
            {
                menumodel = r.Genres.FirstOrDefault(x => x.id_genre_ == id);
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            var menumodel = new Genre();
            TryUpdateModel(menumodel);

            using (var r = new GenreEntities())
            {
                var m = r.Genres.Remove(r.Genres.FirstOrDefault(x => x.id_genre_ == id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
