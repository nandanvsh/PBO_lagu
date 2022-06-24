using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lagu.Entity;

namespace lagu.Controllers
{
    [Authorize]
    public class BandController : Controller
    {
        // GET: Band
        public ActionResult Index()
        {
            List<Band> m;
            using (var r = new BandEntities())
            {
                m = r.Bands.ToList();
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
            var Bandmodel = new Band();
            TryUpdateModel(Bandmodel);

            using (var r = new BandEntities())
            {
                r.Bands.Add(Bandmodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menumodel = new Band();
            TryUpdateModel(menumodel);

            using (var r = new BandEntities())
            {
                menumodel = r.Bands.FirstOrDefault(x => x.id_band == id);
            }

            return View(menumodel);
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            var menumodel = new Band();
            TryUpdateModel(menumodel);

            using (var r = new BandEntities())
            {
                menumodel = r.Bands.FirstOrDefault(x => x.id_band == id);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            var menumodel = new Band();
            TryUpdateModel(menumodel);

            using (var r = new BandEntities())
            {
                var m = r.Bands.Where(x => x.id_band == id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            var menumodel = new Band();
            TryUpdateModel(menumodel);

            using (var r = new BandEntities())
            {
                menumodel = r.Bands.FirstOrDefault(x => x.id_band == id);
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            var menumodel = new Band();
            TryUpdateModel(menumodel);

            using (var r = new BandEntities())
            {
                var m = r.Bands.Remove(r.Bands.FirstOrDefault(x => x.id_band == id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

