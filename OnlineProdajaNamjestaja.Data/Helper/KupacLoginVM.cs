using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineProdajaNamjestaja.Web.ViewModels
{
    public class KupacLoginVM
    {

        public int KupacId { get; set; }
        public string ImePrezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }
    }
}
