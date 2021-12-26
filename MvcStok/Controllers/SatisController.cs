using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            List<SelectListItem> degerler = (from i in db.TBLURUNLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNADI,
                                                 Value = i.URUNID.ToString()
                                             }
                                            ).ToList();
            List<SelectListItem> degerler1 = (from i in db.TBLMUSTERILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }
                                ).ToList();
            ViewBag.degerler = degerler;
            ViewBag.degerler1 = degerler1;
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            var sts = db.TBLURUNLER.Where(m => m.URUNID == p.TBLURUNLER.URUNID).FirstOrDefault();
            p.TBLURUNLER = sts;
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}