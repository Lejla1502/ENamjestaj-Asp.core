using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineProdajaNamjestaja.Web.Controllers
{
    public class ZaposlenikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}