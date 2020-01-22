using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Data.Models;
using OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.Controllers
{
        [Autorizacija( true, true,true,false)]
        [Audit]
    [Area("ModulAdministrator")]
    public class SesijaController : Controller
        {
            private MojContext _db;

            public SesijaController(MojContext db)
            {
                _db = db;
            }

            public IActionResult Index()
            {

                SesijaIndexVM model = new SesijaIndexVM();
                model.Rows = _db.AutorizacijskiToken.Select(s => new SesijaIndexVM.Row
                {
                    VrijemeLogiranja = s.VrijemeEvidentiranja,
                    token = s.Vrijednost,
                    IpAdresa = s.IpAdresa
                }).ToList();
                model.TrenutniToken = HttpContext.GetTrenutniToken();

            
                
                return View(model);
            }

            public IActionResult Obrisi(string token)
            {
                AutorizacijskiToken obrisati = _db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
                if (obrisati != null)
                {
                    _db.AutorizacijskiToken.Remove(obrisati);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
