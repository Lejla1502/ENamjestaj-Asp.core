using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulKupac.ViewModels
{
    public class AkcijskiKatalogIndexVM
    {

        public List<ProizvodiKatalogInfo> Proizvodi { get; set; }
        public string NazivKataloga { get; set; }

        public class ProizvodiKatalogInfo
        {
            public int Id { get; set; }
            public decimal Cijena { get; set; }
            public string Naziv { get; set; }
            public string Sifra { get; set; }
            public string Slika { get; set; }
            public int? Popust { get; set; }
            public decimal? KonacnaCijena { get; set; }
            //public bool ViseBoja { get; set; }
            //public string Boja { get; set; }
            public int BrojacBoja { get; set; }
            public string Vrsta { get; set; }
        }
    }
}
