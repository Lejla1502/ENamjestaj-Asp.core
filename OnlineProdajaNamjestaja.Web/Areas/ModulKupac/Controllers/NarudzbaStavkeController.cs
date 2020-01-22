using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.Areas.ModulKupac.ViewModels;

using OnlineProdajaNamjestaja.Data.Helper;
using System.Globalization;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulKupac.Controllers
{
    [Autorizacija(false,true, false, false)]
    [Audit]
    [Area("ModulKupac")]
    public class NarudzbaStavkeController : Controller
    {

        MojContext ctx = new MojContext();

        public IActionResult Index()
        {
            //KupacLoginVM k = null; //HttpContext.GetLogiraniKorisnik();
            //AktivnaNarudzba n = HttpContext.GetAktivnaNarudzba();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();
            
            int brojAktivnihNarudzbi = ctx.Narudzba.Where(x => x.KupacId == kupac.Id && x.Aktivna==true).Count();

            if (brojAktivnihNarudzbi>0 )
            {
                Narudzba n = ctx.Narudzba.Where(x => x.KupacId==kupac.Id && x.Aktivna == true).First();
                NarudzbaStavkeIndexVM model = new NarudzbaStavkeIndexVM
                {
                    NarudzbaID = n.Id,
                    proizvodiNarudzbe = ctx.NarudzbaStavka.Where(y => y.NarudzbaId == n.Id).Select(x => new NarudzbaStavkeIndexVM.NarudzbaInfo
                    {
                        NarudzbastavkaID = x.Id,
                        Proizvod = x.Proizvod.Naziv,
                        VrstaProizvoda = x.Proizvod.VrstaProizvoda.Naziv,
                        Boja = x.Boja.Naziv,
                        Cijena = x.CijenaProizvoda.ToString("0.00"),
                        Popust=x.PopustNaCijenu.ToString("0.00"),
                        KonacnaCijena=((x.CijenaProizvoda-(x.CijenaProizvoda*x.PopustNaCijenu/100))).ToString("0.00"),
                        Kolicina = x.Kolicina,
                        Total = x.TotalStavke.ToString("0.00")
                    }).ToList(),
                    SumTotal = Convert.ToDecimal(ctx.NarudzbaStavka.Where(y => y.NarudzbaId == n.Id).Sum(y=>y.TotalStavke)).ToString("0.00", new CultureInfo("en-US", false))// System.Globalization.CultureInfo.InvariantCulture)
                };
                return View(model);
            }
            else
                return View(null);
        }

        [Autorizacija(false,true, false, false)]

        public IActionResult Obrisi(int id, int narudzbaID)
        {
            NarudzbaStavka ns = ctx.NarudzbaStavka.Find(id);
            ctx.NarudzbaStavka.Remove(ns);
            ctx.SaveChanges();

            //AktivnaNarudzba a = null; //HttpContext.GetAktivnaNarudzba();
            Narudzba a = ctx.Narudzba.Find(narudzbaID);
            int brojStavki = ctx.NarudzbaStavka.Where(x => x.NarudzbaId == a.Id).Count();
            if (brojStavki < 1)
            {
                Narudzba narudzbaZaBrisanje = ctx.Narudzba.Find(a.Id);
                ctx.Narudzba.Remove(narudzbaZaBrisanje);
                ctx.SaveChanges();

                //HttpContext.SetAKtivnaNarudzba(null);
            }

            
            return RedirectToAction("Index","NarudzbaStavke");
        }
    }

}