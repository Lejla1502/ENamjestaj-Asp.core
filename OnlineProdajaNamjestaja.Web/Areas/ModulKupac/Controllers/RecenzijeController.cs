using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.Areas.ModulKupac.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulKupac.Controllers
{
   [Audit]
    [Area("ModulKupac")]
    public class RecenzijeController : Controller
    {
        MojContext ctx = new MojContext();
        [Autorizacija(false,true, false,true)]
        public IActionResult Index(int proizvodId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            //Kupac kc = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();
            RecenzijeIndexVM model = new RecenzijeIndexVM {
                ProizvodId = proizvodId,
                Recenzijes = ctx.Recenzija.Where(x => x.ProizvodId == proizvodId ).Select(y => new RecenzijeIndexVM.RecenzijeInfo
                {
                    Sadrzaj = y.Sadrzaj,
                    Datum = y.Datum,
                    ImeKupca=ctx.Kupac.Where(o=>o.Id==y.KupacId).FirstOrDefault().Ime+" "+ ctx.Kupac.Where(o => o.Id == y.KupacId).FirstOrDefault().Prezime,
                    Ocjena=y.Ocjena
                }).ToList()
            };
        
        

            return PartialView(model);
        }

        [Autorizacija(false,true, false,false)]
        public IActionResult Dodaj(int proizvodId)
        {
            RecenzijeDodajVM model = new RecenzijeDodajVM {
                ProizvodId=proizvodId
            };



            return PartialView(model);
        }

        [Autorizacija(false,true, false, false)]
        public IActionResult Snimi(RecenzijeDodajVM model)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x=>x.KorisnikId==k.Id).FirstOrDefault();

            Recenzija r = new Recenzija {
                Datum=DateTime.Now,
                KupacId=kupac.Id,
                ProizvodId=model.ProizvodId,
                Sadrzaj=model.Sadrzaj,
                Ocjena=model.Ocjena
            };

            ctx.Recenzija.Add(r);
            ctx.SaveChanges();

            return RedirectToAction("Index","Recenzije", new { @proizvodId = model.ProizvodId });
        }
    }
}