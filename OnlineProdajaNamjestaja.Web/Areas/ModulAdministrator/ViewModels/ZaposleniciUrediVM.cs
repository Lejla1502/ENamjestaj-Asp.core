using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulAdministrator.ViewModels
{
    public class ZaposleniciUrediVM
    {
        public int ZaposlenikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Molimo unesite korisnicko ime")]
        [MaxLength(16)]
        [MinLength(3, ErrorMessage = "Korisnicko ime mora sadrzavati minimalno 3 karaktera")]

        [Remote(action: "VerifyUsername", controller: "Zaposlenici", areaName: "ModulAdministrator", AdditionalFields = "ZaposlenikId")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Molimo unesite sifru"),
            MaxLength(14), MinLength(3, ErrorMessage = "Sifra mora imati minimalno 3 karaktera")]
        public string Lozinka { get; set; }
        [Required(ErrorMessage = "Molimo potvrdite sifru"),
            MaxLength(14), MinLength(3, ErrorMessage = "Sifra mora imati minimalno 3 karaktera")]
        [Remote(action: "ProvjeraPassworda", controller: "Zaposlenici", areaName: "ModulAdministrator", AdditionalFields = "Lozinka")]
        public string PotvrdaLozinke { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati ulogu")]
        public int UlogaID { get; set; }
        public List<Uloga> Uloge { get; set; }
    }
}
