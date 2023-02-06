using Generiraj;
using OmegaApp.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmegaApp.Forme.BazaPodataka
{
    public partial class DodajKorisnika : Form
    {
        int brojac = 1;
        Zaposlenici odabraniZaposlenik;
        /// <DodajKorisnika()>
        /// Koristimo istu formu za dodavanje i izmjenu korisnika u bazi. 
        /// Ovisno o načinu preko kojeg otvaramo "dodajemo formu" (new Form()), prema tome odredujemo koje
        /// cemo gumbice sakriti, a koje cemo prikazati i slicno.
        /// Na slican nacin radi i donja funkcija
        /// </DodajKorisnika()>
        public DodajKorisnika()
        {
            InitializeComponent();
            GenerirajGumb.Enabled = true;
            DodajGumb.Text = "Dodaj";
            DodajGumb.Enabled = false;
            KorisnickoImeTextBox.Enabled = false;
            LozinkaTextBox.Enabled = false;
            IDTextBox.Visible = false;
            IDLabel.Visible = false;
        }
        public DodajKorisnika(Zaposlenici poslaniZaposlenik)
        {
            InitializeComponent();
            odabraniZaposlenik = poslaniZaposlenik;
            PopuniParametre();
            GenerirajGumb.Enabled = false;
            DodajGumb.Text = "Izmjeni";
            DodajGumb.Enabled = true;
        }

        /// <PopuniParametre()>
        /// Ukoliko šaljemo zaposlenika, odnosno ukoliko smo se odlucili za izmjenu zaposlenika, popunimo formu
        /// Njezine textBoxove s odredenim parametrima, proslijedenog korisnika
        /// </PopuniParametre()>
        private void PopuniParametre()
        {
            IDTextBox.Text = odabraniZaposlenik.IDKorisnika.ToString();
            OIBTextBox.Text = odabraniZaposlenik.OIB;
            ImeTextBox.Text = odabraniZaposlenik.Ime;
            PrezimeTextBox.Text = odabraniZaposlenik.Prezime;
            EMailTextBox.Text = odabraniZaposlenik.Email;
            UlogaTextBox.Text = odabraniZaposlenik.Uloga;
            RadnoMjestoTextBox.Text = odabraniZaposlenik.RadnoMjesto;
            KorisnickoImeTextBox.Text = odabraniZaposlenik.KorisnickoIme;
            LozinkaTextBox.Text = odabraniZaposlenik.Lozinka;
            AdresaTextBox.Text = odabraniZaposlenik.Adresa;
            OdjelTextBox.Text = odabraniZaposlenik.Odjel;
        }
        private void OdustaniGumb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <DodajGumb_Click>
        /// Dodajemo, ili mijenjamo podatke odredenog(odabranog) zaposlenika.
        /// <DodajGumb_Click>
        private void DodajGumb_Click(object sender, EventArgs e)
        {
            if (DodajGumb.Text == "Dodaj")
            {
                if (ProvjeriEmail() && ProvjeriUlogu() && ProvjeriOIB() && !ProvjeriUnique())
                {
                    Database.Instance.Connect();
                    string SQLComanda = $"INSERT INTO Zaposlenici (OIB, Ime, Prezime, EMail,  Uloga, Odjel, RadnoMjesto, KorisnickoIme, Lozinka, Adresa) VALUES ('{OIBTextBox.Text}', '{ImeTextBox.Text}', '{PrezimeTextBox.Text}', '{EMailTextBox.Text}', '{UlogaTextBox.Text}', '{OdjelTextBox.Text}', '{RadnoMjestoTextBox.Text}', '{KorisnickoImeTextBox.Text}', '{LozinkaTextBox.Text}', '{AdresaTextBox.Text}')";
                    Database.Instance.ExecuteCommand(SQLComanda);
                    MessageBox.Show("Uspjesno sam dodao korisnika");
                    Database.Instance.Disconnect();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Greska");
                }
            }
            if (DodajGumb.Text == "Izmjeni")
            {
                if (ProvjeriEmail() && ProvjeriUlogu() && ProvjeriOIB() && !ProvjeriUnique())
                {
                    Database.Instance.Connect();
                    string SQLComanda = $"UPDATE Zaposlenici SET OIB = '{OIBTextBox.Text}',  Ime = '{ImeTextBox.Text}', Prezime = '{PrezimeTextBox.Text}', Email = '{EMailTextBox.Text}',  Uloga = '{UlogaTextBox.Text}', Odjel = '{OdjelTextBox.Text}', RadnoMjesto = '{RadnoMjestoTextBox.Text}', KorisnickoIme = '{KorisnickoImeTextBox.Text}', Lozinka = '{LozinkaTextBox.Text}', Adresa = '{AdresaTextBox.Text}' WHERE IDKorisnika = '{IDTextBox.Text}'";
                    Database.Instance.ExecuteCommand(SQLComanda);
                    MessageBox.Show("Uspjesno sam izmjenio korisnika");
                    Database.Instance.Disconnect();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Greska");
                }
            }
            
        }

        /// <ProvjeriOIB>
        /// Provjerava OIB, OIB mora sadrzavati 11 znakova
        /// </ProvjeriOIB>
        /// <returns>bool</returns>
        private bool ProvjeriOIB()
        {
            if (OIBTextBox.TextLength == 11)
            {
                return true;
            }
            else
            {
                MessageBox.Show("OIB mora sadržavati 11 znakova!", "GRESKA", MessageBoxButtons.OK);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ProvjeriEmail()
        {
            if (EMailTextBox.Text.Contains("@") && (EMailTextBox.Text.Contains(".com") || EMailTextBox.Text.Contains(".hr")))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Email adresa nije pravilno unesena!", "GRESKA", MessageBoxButtons.OK);
                return false;
            }
        }
        private bool ProvjeriUlogu()
        {
            if (UlogaTextBox.Text == "Administrator" || UlogaTextBox.Text == "Korisnik")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Uloga mora biti ili korisnik ili administrator", "GRESKA", MessageBoxButtons.OK);
                return false;
            }
        }
        /// <GenerirajGumb_Click>
        /// Generira korisnicko ime i lozinku zaposlenika kojeg smo napravili koristeci Generiraj.dll biblioteku.
        /// </GenerirajGumb_Click>
        private void GenerirajGumb_Click(object sender, EventArgs e)
        {
            Zaposlenici noviZaposlenik = new Zaposlenici(ProvjeriDuplikateKorisnickogImena(), OIBTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text);
            KorisnickoImeTextBox.Text = noviZaposlenik.GenerirajKorisnickoIme(ProvjeriDuplikateKorisnickogImena(), ImeTextBox.Text, PrezimeTextBox.Text);
            LozinkaTextBox.Text = noviZaposlenik.GenerirajLozinku();
            DodajGumb.Enabled = true;
        }
        /// <ProvjeriDuplikateKorisnickogImena>
        /// Provjerava je li u bazi postoje dva korisnika s istim imenom i prezimenom
        /// To nam ovisi o njegovom korisnickom imenu, posto korisnicko ime mora biti unikatno
        /// Brojac ce brojiti koliko imamo takvih zaposlenika u bazi.
        /// </ProvjeriDuplikateKorisnickogImena>
        /// <returns>int</returns>
        private int ProvjeriDuplikateKorisnickogImena()
        {
            Database.Instance.Connect();
            List<Zaposlenici> listaSvih = new List<Zaposlenici>();
            string SQLUpit = "SELECT * FROM Zaposlenici";

            IDataReader citac = Database.Instance.GetDataReader(SQLUpit);

            while (citac.Read())
            {
                int id = int.Parse(citac["IDKorisnika"].ToString());
                string oib = citac["OIB"].ToString();
                string ime = citac["Ime"].ToString();
                string prezime = citac["Prezime"].ToString();
                string email = citac["EMail"].ToString();
                string uloga = citac["Uloga"].ToString();
                string odjel = citac["Odjel"].ToString();
                string radnoMjesto = citac["RadnoMjesto"].ToString();
                string korisnckoIme = citac["KorisnickoIme"].ToString();
                string lozinka = citac["Lozinka"].ToString();
                string adresa = citac["Adresa"].ToString();
                Zaposlenici trenutniZaposlenik = new Zaposlenici(id, oib, ime, prezime)
                {
                    Email = email,
                    Uloga = uloga,
                    Odjel = odjel,
                    RadnoMjesto = radnoMjesto,
                    KorisnickoIme = korisnckoIme,
                    Lozinka = lozinka,
                    Adresa = adresa
                };
                listaSvih.Add(trenutniZaposlenik);
            }
            citac.Close();
            Database.Instance.Disconnect();

            foreach (Zaposlenici zaposlenik in listaSvih)
            {
                if (zaposlenik.Ime.Substring(0, 1).ToLower() == ImeTextBox.Text.Substring(0, 1).ToLower() && zaposlenik.Prezime.ToLower() == PrezimeTextBox.Text.ToLower())
                {
                    brojac++;
                }
            }
            return brojac;
        }
        /// <ProvjeriUnique()>
        /// Po što imamo neka ograničenja u bazi (UNIQUE) tipa EMail, OIB i slično što nam je jedinstveno za svakog korisnika
        /// Moramo provjeriti je li imamo neke iste podatke u bazi
        /// Ako imamo vraćamo bool koji nam neće dozvoliti izmjenu/unos korisnika
        /// Ako nemamo unos/izmjena će nam biti omogućena
        /// </ProvjeriUnique>
        /// <returns>bool</returns>
        private bool ProvjeriUnique()
        {
            Database.Instance.Connect();
            List<Zaposlenici> listaSvih = new List<Zaposlenici>();
            string SQLUpit = "SELECT * FROM Zaposlenici";

            IDataReader citac = Database.Instance.GetDataReader(SQLUpit);

            while (citac.Read())
            {
                int id = int.Parse(citac["IDKorisnika"].ToString());
                string oib = citac["OIB"].ToString();
                string ime = citac["Ime"].ToString();
                string prezime = citac["Prezime"].ToString();
                string email = citac["EMail"].ToString();
                string uloga = citac["Uloga"].ToString();
                string odjel = citac["Odjel"].ToString();
                string radnoMjesto = citac["RadnoMjesto"].ToString();
                string korisnckoIme = citac["KorisnickoIme"].ToString();
                string lozinka = citac["Lozinka"].ToString();
                string adresa = citac["Adresa"].ToString();
                Zaposlenici trenutniZaposlenik = new Zaposlenici(id, oib, ime, prezime)
                {
                    Email = email,
                    Uloga = uloga,
                    Odjel = odjel,
                    RadnoMjesto = radnoMjesto,
                    KorisnickoIme = korisnckoIme,
                    Lozinka = lozinka,
                    Adresa = adresa
                };
                listaSvih.Add(trenutniZaposlenik);
            }
            citac.Close();
            Database.Instance.Disconnect();
            if (DodajGumb.Text == "Izmjeni")
            {
                Zaposlenici uListi = null;
                foreach (Zaposlenici zaposlenik in listaSvih)
                {
                    if (odabraniZaposlenik.IDKorisnika == zaposlenik.IDKorisnika)
                    {
                        uListi = zaposlenik;
                        break;
                    }
                }
                if (uListi != null)
                {
                    listaSvih.Remove(uListi);
                }
            }
            bool duplikat = false;
            foreach (Zaposlenici zaposlenik in listaSvih)
            {
                if ((zaposlenik.KorisnickoIme == KorisnickoImeTextBox.Text || zaposlenik.OIB == OIBTextBox.Text || zaposlenik.Email == EMailTextBox.Text))
                {
                    duplikat = true;
                    break;
                }
                else
                {
                    duplikat = false;
                }
            }
            return duplikat;
        }
    }
}
