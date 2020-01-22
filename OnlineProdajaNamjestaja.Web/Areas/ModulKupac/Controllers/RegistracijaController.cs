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
    [Autorizacija(false,true, false, true)]
    [Area("ModulKupac")]
    public class RegistracijaController : Controller
    {
        MojContext ctx = new MojContext();

        public IActionResult Index()
        {
            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
                Opstine = ctx.Opstina.ToList()
            };

            return View(model);
        }

        public IActionResult Snimi(RegistracijaIndexVM model)
        {
            Korisnik k = new Korisnik {
                KorisnickoIme = model.KorisnickoIme,
                Lozinka = model.Lozinka,
                OpstinaId = model.OpstinaID,
                UlogaId = 5
            };

            ctx.Korisnik.Add(k);
            ctx.SaveChanges();

            Kupac kupac = new Kupac {
                Ime = model.Ime,
                Prezime = model.Prezime,
                Email = model.Email,
                Adresa = model.Adresa,
                Spol = model.Spol,
                KorisnikId = k.Id
            };

            ctx.Kupac.Add(kupac);
            ctx.SaveChanges();

            HttpContext.SetLogiraniKorisnik(k);
            return RedirectToAction("PrikazPoruke");


        }

        public IActionResult PrikazPoruke()
        {

            return View();
        } 

        public IActionResult ProvjeraPassworda(string PotvrdaLozinke, string Lozinka)
        {
            if (PotvrdaLozinke.Equals(Lozinka))
                return Json(true);
            return Json("Sifre se ne podudaraju");
        }

        
        public IActionResult VerifyUsername(string KorisnickoIme)
        {
            if(ctx.Korisnik.Any(x => x.KorisnickoIme == KorisnickoIme))
                return Json($"Korisnicko ime {KorisnickoIme} već postoji");
            return Json(true);
        }

        
        public IActionResult VerifyEmail(string Email)
        {
            if (ctx.Kupac.Any(x => x.Email == Email))
                return Json($"Unešeni email {Email} već postoji");
            return Json(true);
        }
    }
}