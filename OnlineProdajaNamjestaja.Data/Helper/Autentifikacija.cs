using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Web;
using Microsoft.Extensions.DependencyInjection;
using OnlineProdajaNamjestaja.Data.Models;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using OnlineProdajaNamjestaja.Web.ViewModels;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;

namespace OnlineProdajaNamjestaja.Data.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik="logirani_korisnik";
        
       

        

        public static Korisnik GetLogiraniKorisnik(this HttpContext context)
        {
            MojContext db = context.RequestServices.GetService<MojContext>();

            string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;

            return db.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.Korisnik)
                .SingleOrDefault();
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static void SetLogiraniKorisnik(this HttpContext context, Korisnik korisnik, bool snimiUCookie = false)
        {

            MojContext db = context.RequestServices.GetService<MojContext>();
            

            string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {
                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);
                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnikId = korisnik.Id,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
        }
       


    }
}