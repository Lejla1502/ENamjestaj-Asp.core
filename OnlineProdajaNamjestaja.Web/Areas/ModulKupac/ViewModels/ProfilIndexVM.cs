﻿using Microsoft.AspNetCore.Mvc;
using OnlineProdajaNamjestaja.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulKupac.ViewModels
{
    public class ProfilIndexVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Opstina { get; set; }

    }
}
