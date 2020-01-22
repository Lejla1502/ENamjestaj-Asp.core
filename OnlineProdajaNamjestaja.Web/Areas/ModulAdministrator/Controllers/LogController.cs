using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data;
using OnlineProdajaNamjestaja.Data.Helper;
using OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.ViewModels;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true, false, false, false)]
    
    [Area("ModulAdministrator")]
    public class LogController : Controller
    {
        MojContext ctx = new MojContext();

        public IActionResult Index()
        {
            LogIndexVM model = new LogIndexVM()
            {
                Audits = ctx.Log.Select(x => new LogIndexVM.Audit {
                    Username=x.Username,
                    IPAddress=x.IPAddress,
                    AreaAccessed=x.AreaAccessed,
                    Timestamp=x.Timestamp
                }).ToList()
            };

            return View(model);
        }
    }
}