using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineProdajaNamjestaja.Data.Helper
{
    public class AktivnaNarudzba
    {
        public int Id { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool Otkazano { get; set; }
    }
}
