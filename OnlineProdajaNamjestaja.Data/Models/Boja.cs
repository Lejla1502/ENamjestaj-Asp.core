using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineProdajaNamjestaja.Data.Models
{
    public class Boja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<ProizvodBoja> ProizvodBojas { get; set; }
    }
}
