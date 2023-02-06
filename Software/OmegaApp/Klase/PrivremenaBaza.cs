using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Klase
{
    public class PrivremenaBaza
    {
        List<Korisnik> listaZaposlenika { get; set; }

        public int brojac = 1;
        public PrivremenaBaza()
        {
            listaZaposlenika = new List<Korisnik>();

            Korisnik admin = new Korisnik(brojac, "11111111111", "Admin", "Admin", "Adminova Kuca 1", "admin@gmail.hr", "Admin", "Sve", "Sve");
            admin.Lozinka = "admin";
            admin.KorisnickoIme = "admin";
            brojac++;

            Korisnik korisnik = new Korisnik(brojac, "22222222222", "Korisnik", "Korisnik", "Korisnikov dom 1", "korisnik@gmail.hr", "Korisnik", "Sve", "Sve");
            korisnik.Lozinka = "korisnik";
            korisnik.KorisnickoIme = "korisnik";
            brojac++;
            listaZaposlenika.Add(admin);
            listaZaposlenika.Add(korisnik);

        }
        public List<Korisnik> VratiSveZaposlenike()
        {
            return listaZaposlenika;
        }
        public string VratiVrijednostBrojaca()
        {
            return brojac.ToString();
        }
        public void DodajZaposlenika(Korisnik dodajNovogKorisnika)
        {
            listaZaposlenika.Add(dodajNovogKorisnika);
        }
        public void ObrisiZaposlenika(Korisnik obirisiKorisnika)
        {
            listaZaposlenika.Remove(obirisiKorisnika);
        }
    }
}
