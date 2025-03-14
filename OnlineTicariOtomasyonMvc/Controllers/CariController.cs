using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonMvc.Models.Siniflar;
namespace OnlineTicariOtomasyonMvc.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();

        // GET: Cari
        public ActionResult Index()
        {
            var value = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCari(Cariler p)
        {   
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPut]
        public ActionResult UpdateCari(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("UpdateCari", cari);
        }

        public ActionResult DeleteCari(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}