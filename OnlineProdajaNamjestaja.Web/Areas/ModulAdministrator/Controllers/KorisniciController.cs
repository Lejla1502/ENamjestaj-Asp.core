using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.ViewModels;
using Serilog;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true,false, false, false)]
    [Audit]
    [Area("ModulAdministrator")]
    public class KorisniciController : Controller
    {
        //private readonly ILogger<KorisniciController> _logger;

        public KorisniciController()
        {
            
        }
        MojContext ctx = new MojContext();
        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            
            return View();
        }

        public IActionResult IndexKupci()
        {
            KupciIndexVM model = new KupciIndexVM {
                Kupci=ctx.Kupac.Select(x=>new KupciIndexVM.KorisnikInfo {
                    KupacId=x.Id,
                    KorisnickoIme=x.Korisnik.KorisnickoIme,
                    Ime=x.Ime,
                    Prezime=x.Prezime
                }).ToList()
            };

            return View(model);
        }

        public IActionResult IndexZaposlenici()
        {
            ZaposleniciIndexVM model = new ZaposleniciIndexVM
            {
                Zaposlenici = ctx.Zaposlenik.Select(x => new ZaposleniciIndexVM.KorisnikInfo
                {
                    ZaposlenikId=x.Id,
                    KorisnickoIme = x.Korisnik.KorisnickoIme,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Uloga=x.Korisnik.Uloga.TipUloge
                }).ToList()
            };

            return View(model);
        }
    }
}