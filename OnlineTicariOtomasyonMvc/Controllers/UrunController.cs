using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonMvc.Models.Siniflar;
namespace OnlineTicariOtomasyonMvc.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var value = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateUrun()
        {
            List<SelectListItem> values = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString(),
                                           }).ToList();

            ViewBag.Kategoriler = values;

            return View();
        }

        [HttpPost]
        public ActionResult CreateUrun(Urun urun)
        {
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteUrun(int id)
        {
            var value = c.Uruns.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PutUrun(int id)
        {
            List<SelectListItem> values = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString(),
                                           }).ToList();

            ViewBag.Kategoriler = values;


            var value = c.Uruns.Find(id);
            return View("PutUrun", value);

        }
        [HttpPost]
        public ActionResult PutUrun(Urun urun)
        {
            var value = c.Uruns.Find(urun.UrunID);
            value.AlisFiyati = urun.AlisFiyati;
            value.Durum = urun.Durum;
            value.UrunAd = urun.UrunAd;
            value.Marka = urun.Marka;
            value.SatisFiyati = urun.SatisFiyati;
            value.KategoriId= urun.KategoriId;
            value.Stok= urun.Stok;
            value.UrunGorsel= urun.UrunGorsel;

            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}