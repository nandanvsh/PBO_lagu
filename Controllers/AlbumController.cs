using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lagu.Entity;


namespace lagu.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        public ActionResult Index()
        {
            List<Album> m;
            using (var r = new AlbumEntities())
            {
                m = r.Albums.ToList();
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
            var albummodel = new Album();
            TryUpdateModel(albummodel);

            using (var r = new AlbumEntities())
            {
                r.Albums.Add(albummodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menumodel = new Album();
            TryUpdateModel(menumodel);

            using (var r = new AlbumEntities())
            {
                menumodel = r.Albums.FirstOrDefault(x => x.Id_album == id);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            var menumodel = new Album();
            TryUpdateModel(menumodel);

            using (var r = new AlbumEntities())
            {
                menumodel = r.Albums.FirstOrDefault(x => x.Id_album == id);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            var menumodel = new Album();
            TryUpdateModel(menumodel);

            using (var r = new AlbumEntities())
            {
                var m = r.Albums.Where(x => x.Id_album == id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            var menumodel = new Album();
            TryUpdateModel(menumodel);

            using (var r = new AlbumEntities())
            {
                menumodel = r.Albums.FirstOrDefault(x => x.Id_album == id);
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            var menumodel = new Album();
            TryUpdateModel(menumodel);

            using (var r = new AlbumEntities())
            {
                var m = r.Albums.Remove(r.Albums.FirstOrDefault(x => x.Id_album == id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
