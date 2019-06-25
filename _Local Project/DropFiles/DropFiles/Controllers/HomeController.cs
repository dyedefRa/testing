using DropFiles.OKUBENI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropFiles.OKUBENI.Model;

namespace DropFiles.Controllers
{
    public class HomeController : Controller
    {
        DropContext dropContext = new DropContext();
        // GET: Home
        public ActionResult Index()
        {
            
            return View(dropContext.wSiparis.ToList());
        }

      //  bir sipariste birden fazla dosya olabilir.
        public ActionResult SiparisDosyaDetay(int siparisId)
        {
            var order = dropContext.wSiparis.FirstOrDefault(x => x.Id == siparisId);
            //var siparis = new Siparis()
            //{
            //    Id = 1,
            //    Ad = "X siparişi",
            //    OlusturulmaTarihi = DateTime.Now
            //};
            //siparis.Dosyalar.Add(new Dosya() { DosyaAdi = "dosyaa", DosyaYolu = @"D:\dosya1.txt", Id = 1 });
            //siparis.Dosyalar.Add(new Dosya() { DosyaAdi = "dosya2", DosyaYolu = @"D:\dosya2.txt", Id = 2 });



            return View(order);
        }

    }
}