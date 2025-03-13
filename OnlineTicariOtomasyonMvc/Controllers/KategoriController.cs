using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonMvc.Models.Siniflar;
namespace OnlineTicariOtomasyonMvc.Controllers
{
    public class KategoriController : Controller
    {

        Context c = new Context();
        // GET: Kategori
        public ActionResult Index()
        {
            var value = c.Kategoris.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateKategori(Kategori kategori)
        {

            c.Kategoris.Add(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteKategori(int id)
        {
            var value = c.Kategoris.Find(id);
            c.Kategoris.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PutKategori(int id)
        {
            var value = c.Kategoris.Find(id);
            return View("PutKategori",value);
        
        }
        [HttpPost]
        public ActionResult PutKategori(Kategori kategori)
        {
            var value = c.Kategoris.Find(kategori.KategoriID);
            value.KategoriAd = kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}