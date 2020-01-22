using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Web.Areas.ModulKupac.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulKupac.Controllers
{
    [Autorizacija(false,true,false,false)]
    [Audit]
    [Area("ModulKupac")]
    public class DostavaController : Controller
    {
        MojContext ctx = new MojContext();
        public IActionResult Index(int narudzbaId, string total)
        {
            DostavaIndexVM model = new DostavaIndexVM {
                Dostave = ctx.Dostava.Select(x=>new DostavaIndexVM.DostavaInfo {
                    Id=x.Id,
                    Cijena=x.Cijena.ToString().Replace(",","."),
                    Opis=x.Opis,
                    Tip=x.Tip
                }).ToList(),
                NarudzbaID = narudzbaId,
                Total = total
            };
            return View(model);
        }
    }
}