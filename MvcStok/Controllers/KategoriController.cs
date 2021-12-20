using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {

        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();

            ViewBag.degerler = degerler;
            return View();
        }
        
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
           
        }

        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            var degerler = db.TBLKATEGORILER.Find(id);
            return View(degerler);
            

        }
        [HttpPost]
        public ActionResult GUNCELLE()
        {
       
            //ViewBag.degerler = degerler;
            




            return RedirectToAction("index");
        }
    }
}