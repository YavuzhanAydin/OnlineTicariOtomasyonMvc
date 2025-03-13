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
    }
}