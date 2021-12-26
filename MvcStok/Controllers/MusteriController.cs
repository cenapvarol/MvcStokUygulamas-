using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
               degerler = degerler.Where(m=>m.)

            }
            var degerler = from d in db.TBLMUSTERILER select d;
            //var degerler = db.TBLMUSTERILER.ToList();
            ViewBag.degerler = degerler.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");

            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id, string confirm_value)
        {

            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGuncelle", mstr);

        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mstr = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mstr.MUSTERIAD = p1.MUSTERIAD;
            mstr.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}