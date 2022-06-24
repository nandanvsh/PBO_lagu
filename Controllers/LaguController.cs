using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lagu.Entity;

namespace lagu.Controllers
{
    [Authorize]
    public class LaguController : Controller
    {
        // GET: Lagu
         public ActionResult Index()
        {
            List<Lagu> m;
            using (var r = new LaguEntities())
            {
                m = r.Lagus.ToList();
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
            var lagumodel = new Lagu();
            TryUpdateModel(lagumodel);

            using (var r = new LaguEntities())
            {
                r.Lagus.Add(lagumodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menumodel = new Lagu();
            TryUpdateModel(menumodel);

            using (var r = new LaguEntities())
            {
                menumodel = r.Lagus.FirstOrDefault(x => x.C_id_lagu == id);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            var menumodel = new Lagu();
            TryUpdateModel(menumodel);

            using (var r = new LaguEntities())
            {
                menumodel = r.Lagus.FirstOrDefault(x => x.C_id_lagu == id);
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            var menumodel = new Lagu();
            TryUpdateModel(menumodel);

            using (var r = new LaguEntities())
            {
                var m = r.Lagus.Where(x => x.C_id_lagu == id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            var menumodel = new Lagu();
            TryUpdateModel(menumodel);

            using (var r = new LaguEntities())
            {
                menumodel = r.Lagus.FirstOrDefault(x => x.C_id_lagu == id);
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            var menumodel = new Lagu();
            TryUpdateModel(menumodel);

            using (var r = new LaguEntities())
            {
                var m = r.Lagus.Remove(r.Lagus.FirstOrDefault(x => x.C_id_lagu == id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }

}

