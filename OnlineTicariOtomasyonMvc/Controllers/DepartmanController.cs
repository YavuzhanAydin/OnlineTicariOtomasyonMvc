using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyonMvc.Models.Siniflar;
namespace OnlineTicariOtomasyonMvc.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();

        // GET: Departman
        public ActionResult Index()
        {
           var values = c.Departmans.Where(x=>x.Durum == true).ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult CreateDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartman(Departman departman)
        {

            c.Departmans.Add(departman);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartman(int id)
        {
            var value = c.Departmans.Find(id);
            value.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartman(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("GetDepartman",dpt);
        }
        public ActionResult PutDepartman(Departman p)
        {
            var dept = c.Departmans.Find(p.DepartmanID);
            dept.DepartmanAd= p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailsDepartman(int id)
        {
            var value = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x=>x.DepartmanID == id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(value);
        }
        public ActionResult DepartmanPersonelSale(int id)
        {
            var value = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x=>x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(value);
        }
    }
}