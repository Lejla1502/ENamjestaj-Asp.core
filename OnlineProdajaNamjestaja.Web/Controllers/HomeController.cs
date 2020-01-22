using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;

namespace OnlineProdajaNamjestaja.Web.Controllers
{
    public class HomeController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            //if (HttpContext.GetLogiraniKorisnik() == null)
            //    return RedirectToAction("Index", "Login");

            //List<Kupac> kupci = db.Kupac.ToList();

            //ViewData["kupci"] = kupci;

            //Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            //if (k == null)
            //    return RedirectToAction("Logout", "Autentifikacija", new { area = "" });

            //  return RedirectToAction("Index", "Home", new { area = "ModulZaposlenik" });
            MojContext ctx = new MojContext();
            List<AkcijskiKatalog> listaKataloga = ctx.AkcijskiKatalog.ToList();
            foreach (var x in listaKataloga)
            {
                if (x.DatumZavrsetka == DateTime.Today)
                {
                    ctx.AkcijskiKatalog.Where(a => a.Id == x.Id).First().Aktivan = false;
                    ctx.SaveChanges();
                }
            }

            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            if (k == null)
                return Redirect("/ModulKupac/Proizvodi/Index");//return RedirectToAction("Logout", "Autentifikacija", new { area = "" });
            else if (k.UlogaId == 1)
                return Redirect("/ModulAdministrator/Korisnici/Index");
            else if (k.UlogaId == 2)
                return Redirect("/ModulMenadzer/ProizvodiMenadzer/Index");
            else
                return Redirect("/ModulKupac/Proizvodi/Index");
           
            //  return RedirectToAction("Index", "Home", new { area = "ModulZaposlenik" });
            // return View() ;
            
        }

        //public IActionResult Login()
        //{
            
            //if (HttpContext.GetLogiraniKorisnik() == null)
            //    return RedirectToAction("Index", "Login");
          //  return View();
        //}

        //    public IActionResult About()
        //    {
        //        ViewData["Message"] = "Your application description page.";

        //        return View();
        //    }

        //    public IActionResult Contact()
        //    {
        //        ViewData["Message"] = "Your contact page.";

        //        return View();
        //    }

        //    public IActionResult Error()
        //    {
        //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
    }
}
