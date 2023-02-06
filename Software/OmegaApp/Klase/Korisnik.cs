using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Klase
{
    public class Korisnik
    {
        public int IDKorisnika { get; set; }
        public string OIB { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Uloga { get; set; }
        public string KorisnickoIme { get; set; }
        public string Odjel { get; set; }
        public string RadnoMjesto { get; set; }
        public string Lozinka { get; set; }


        public Korisnik(int broj, string oib, string ime, string prezime, string adresa, string email, string uloga, string odjel, string radnomjesto)
        {
            this.IDKorisnika = broj;
            this.OIB = oib;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.Uloga = uloga;
            this.Adresa = adresa;
            this.Odjel = odjel;
            this.RadnoMjesto = radnomjesto;
        }
    }
}
