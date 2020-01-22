using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        MojContext ctx = new MojContext();
        

        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true,
            });
        }
        public IActionResult Login(LoginVM input)
        {
            Korisnik korisnik = ctx.Korisnik
                .SingleOrDefault(x => x.KorisnickoIme == input.username && x.Lozinka == input.password);

            if (korisnik == null)
            {
                ViewData["poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            //Autentifikacija.PokreniNovuSesiju(korisnik, HttpContext);
            //Autentifikacija.
            HttpContext.SetLogiraniKorisnik(korisnik);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            //Autentifikacija.PokreniNovuSesiju(null, HttpContext);
            HttpContext.SetLogiraniKorisnik(null);

            return RedirectToAction("Index");
        }
    }
}