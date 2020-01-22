using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Web.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Controllers
{
    public class LoginController : Controller
    {
        private MojContext _db;

        public LoginController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
           
           // HttpContext.SetLogiraniKorisnik(null);
            return RedirectToAction("Index");
        }

        public ActionResult Provjera(string username, string password)
        {

            KupacLoginVM Kupac = null;// _db.Kupac.Where(x => x.KorisnickoIme == username).Select(s => new KupacLoginVM
            //{
            //    Username = s.KorisnickoIme,
            //    ImePrezime = s.Ime + " " + s.Prezime,
            //    KupacId = s.Id,
            //    Email = s.Email,
            //    Adresa = s.Adresa,
            //    Spol=s.Spol
            //}).FirstOrDefault();

           // HttpContext.SetLogiraniKorisnik(Kupac);

            //HttpContext.Session.SetString("nekiKey",Kupac.Username);------->sesija s videa(6-autentifikacija)
            
            if (Kupac == null)
                return RedirectToAction("Index", "Login");
            else
            {
                //HttpContext.SetAKtivnaNarudzba(_db.Narudzba.Where(n => n.KupacId == Kupac.KupacId).FirstOrDefault(s => s.Status == true));
                return RedirectToAction("Index", "Home");
            }

           
        }
    }
}