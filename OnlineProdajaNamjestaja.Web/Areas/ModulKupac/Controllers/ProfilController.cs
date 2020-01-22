using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.Areas.ModulKupac.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulKupac.Controllers
{
    [Autorizacija(false,true, false, false)]
    [Area("ModulKupac")]
    public class ProfilController : Controller
    {
        MojContext ctx = new MojContext();
       // private readonly UserManager<ProfilUrediVM> _userManager;

        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();

            ProfilIndexVM model = new ProfilIndexVM {
                Ime=kupac.Ime,
                Prezime=kupac.Prezime,
                KorisnickoIme=k.KorisnickoIme,
                Email=kupac.Email,
                Adresa=kupac.Adresa,
                Opstina=ctx.Opstina.Where(o=>o.Id==k.OpstinaId).FirstOrDefault().Naziv
            };

            return View(model);
        }

        public IActionResult VerifyUsername(string KorisnickoIme)
        {
            Korisnik ko = HttpContext.GetLogiraniKorisnik();
            List<Korisnik> korisnici = ctx.Korisnik.ToList();
            foreach (Korisnik k in korisnici)
            {
                if (k.Id != ko.Id)
                {
                    if (k.KorisnickoIme == KorisnickoIme)
                        return Json($"Korisnicko ime {KorisnickoIme} već postoji");
                }
                 
            }
            return Json(true);
        }


        public IActionResult VerifyEmail(string Email)
        {
            Korisnik ko = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == ko.Id).FirstOrDefault();
            List<Kupac> kupci = ctx.Kupac.ToList();
            foreach (Kupac k in kupci)
            {
                if (k.Id != kupac.Id)
                {
                    if (k.Email == Email)
                        return Json($"Korisnicko ime {Email} već postoji");
                }

            }
            return Json(true);
        }

        public IActionResult Uredi()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();
            ProfilUrediVM model = new ProfilUrediVM {
                Ime=kupac.Ime,
                Prezime=kupac.Prezime,
                KorisnickoIme=k.KorisnickoIme,
                Lozinka=k.Lozinka,
                PotvrdaLozinke=k.Lozinka,
                Email=kupac.Email,
                Adresa=kupac.Adresa,
                OpstinaID=k.OpstinaId,
                Opstine=ctx.Opstina.ToList()
            };

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> SnimiK(ProfilUrediVM model)
        //{
        //    IdentityResult x=await _userManager.UpdateAsync(model)
        //}

        public IActionResult Snimi(ProfilUrediVM model)
        {

            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();
            k.KorisnickoIme = model.KorisnickoIme;
            k.Lozinka = model.Lozinka;
            k.OpstinaId=model.OpstinaID;
            HttpContext.SetLogiraniKorisnik(k);
            ctx.SaveChanges();

           

            kupac.Email = model.Email;
            kupac.Adresa = model.Adresa;
            
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}