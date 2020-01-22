using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.Areas.ModulMenadzer.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulMenadzer.Controllers
{

    [Autorizacija( false,false,  true,false)]
    [Audit]
    [Area("ModulMenadzer")]
    public class AkcijskiKatalogController : Controller
    {
        MojContext ctx = new MojContext();

        public IActionResult Index()
        {
            List<AkcijskiKatalog> listaKataloga = ctx.AkcijskiKatalog.ToList();

            bool postojiAktivan = false;
            foreach (var lk in listaKataloga)
            {
                if (lk.Aktivan == true)
                    postojiAktivan = true;
            }

            AkcijskiKatalogIndexVM model = new AkcijskiKatalogIndexVM
            {
                daLiJeIjedanKatalogAktivan=postojiAktivan,
                Katalozi=ctx.AkcijskiKatalog.Select(x=>new AkcijskiKatalogIndexVM.KatalogInfo
                {
                    Id=x.Id,
                    Opis=x.Opis,
                    DatumPocetka=x.DatumPocetka.Date,
                    DatumZavrsetka=x.DatumZavrsetka.Date,
                    Aktivan=x.Aktivan
                }).ToList()
            };

            
            

            return View(model);
        }

        public IActionResult Dodaj()
        {
            AkcijskiKatalogDodajVM model = new AkcijskiKatalogDodajVM();
            return PartialView(model);
        }

        public IActionResult Obrisi(int katalogId)
        {
            AkcijskiKatalog a = ctx.AkcijskiKatalog.Find(katalogId);

            foreach (KatalogStavka x in ctx.KatalogStavka.Where(x => x.AkcijskiKatalogId == katalogId).ToList())
            {
                ctx.KatalogStavka.Remove(x);
                ctx.SaveChanges();
            }

            ctx.AkcijskiKatalog.Remove(a);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Snimi(AkcijskiKatalogDodajVM a)
        {
            AkcijskiKatalog ak = new AkcijskiKatalog();
            ak.Opis = a.Opis;
            ak.DatumPocetka = (DateTime)a.DatumPocetka;
            ak.DatumZavrsetka =(DateTime) a.DatumZavrsetka;
            ak.Aktivan = true;

            ctx.AkcijskiKatalog.Add(ak);
            ctx.SaveChanges();

            return RedirectToAction("Index", "AkcijskiKatalog");
        }

        public IActionResult ProizvodiDodaj(int katalogId)
        {
            AkcijskiKatalogStavkeDodajVM model = new AkcijskiKatalogStavkeDodajVM {
                Proizvodi=ctx.Proizvod.Select(x=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem {
                    Value=x.Id.ToString(),
                    Text=x.Naziv
                }).ToList(),
                KatalogID=katalogId
            };



            return PartialView(model);
        }

        public IActionResult ProizvodiIndex(int katalogId)
        {
            AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(katalogId);
            AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM {
                KatalogId=katalogId,
                KatalogProizvodi=ctx.KatalogStavka.Where(y=>y.AkcijskiKatalogId==ak.Id).Select(x=>new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo {
                    Id=x.Id,
                    Proizvod=x.Proizvod.Naziv,
                    Cijena=x.Proizvod.Cijena,
                    Procenat=x.PopustProcent,
                    KonacnaCijena=Convert.ToDecimal( x.Proizvod.Cijena-(x.Proizvod.Cijena * x.PopustProcent / 100))
                }).ToList()
            };
            return PartialView(model);
        }

        
        public IActionResult ObrisiProizvod(int katalogId,int stavkaId)
        {
            KatalogStavka ks = ctx.KatalogStavka.Find(stavkaId);
            ctx.KatalogStavka.Remove(ks);
            ctx.SaveChanges();

            return RedirectToAction("ProizvodiIndex",new{ @katalogId = katalogId });
        }


        public IActionResult SnimiProizvod(AkcijskiKatalogStavkeDodajVM a)
        {
            if (ModelState.IsValid)
            {
                KatalogStavka ks = new KatalogStavka
                {
                    PopustProcent = a.Procenat,
                    ProizvodId = a.ProizvodID,
                    AkcijskiKatalogId = a.KatalogID
                };

                ctx.KatalogStavka.Add(ks);
                ctx.SaveChanges();

                int katalogId = a.KatalogID;
                AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(a.KatalogID);
                AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
                {
                    KatalogId = katalogId,
                    KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                    {
                        Id = x.Id,
                        Proizvod = x.Proizvod.Naziv,
                        Cijena = x.Proizvod.Cijena,
                        Procenat = x.PopustProcent,
                        KonacnaCijena = x.Proizvod.Cijena * x.PopustProcent/100
                    }).ToList()
                };
                return PartialView("ProizvodiIndex", model);
            }
            else
            {
                int katalogId = a.KatalogID;
                AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(a.KatalogID);
                AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
                {
                    KatalogId = katalogId,
                    KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                    {
                        Id = x.Id,
                        Proizvod = x.Proizvod.Naziv,
                        Cijena = x.Proizvod.Cijena,
                        Procenat = x.PopustProcent,
                        KonacnaCijena = x.Proizvod.Cijena - Convert.ToDecimal(x.Proizvod.Cijena / x.PopustProcent)
                    }).ToList()
                };

                return PartialView("ProizvodiIndex", model);
            }
            
           
        }
    }
}