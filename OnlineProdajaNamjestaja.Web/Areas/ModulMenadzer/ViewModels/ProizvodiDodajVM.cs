﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using OnlineProdajaNamjestaja.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineProdajaNamjestaja.Web.Areas.ModulMenadzer.ViewModels
{
    public class ProizvodiDodajVM
    {
        public int ProizvodId { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti naziv proizvoda")]
        [MinLength(3,ErrorMessage ="Naziv mora sadrzavati minimalno 3 karaktera")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti sifru proizvoda")]
        [RegularExpression(@"^(\d{1,8})\b",ErrorMessage ="Potrebno je unijeti broj u rasponu 1-8 ")]
        [Remote(action: "VerifySifra", controller: "ProizvodiMenadzer", areaName:"ModulMenadzer", AdditionalFields ="ProizvodId")]
        public string Sifra { get; set; }
        [Required(ErrorMessage = "Obavezno je unijeti cijenu proizvoda")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.0}")]
       
        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "Potrebno je unijeti decimalni broj")]
        public string Cijena { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati vrstu proizvoda")]
        public int VrstaID { get; set; }
        public List<VrstaProizvoda> Vrste { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati boju")]
        public int[] BojeID { get; set; }
        public SelectList Boje { get; set; }
        //public List<Boja> Boje { get; set; }
        //[Required(ErrorMessage ="Obavezno je odabrati sliku")]
        //[DisplayName("Upload file")]
        public string Slika { get; set; }

        [Required(ErrorMessage = "Upload slike je neophodan")] 
        [Display(Name = "Upload slike")]
        public IFormFile UploadPic { get; set; }
        

        

        
    }

    
}