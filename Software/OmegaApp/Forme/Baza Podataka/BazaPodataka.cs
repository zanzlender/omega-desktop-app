using Generiraj;
using OmegaApp.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OmegaApp.Forme.BazaPodataka
{
    public partial class BazaPodataka : Form
    {
        NotifyIcon notifyIcon;
        Zaposlenici primljeniZaposleni;
        public BazaPodataka(Zaposlenici primljeni)
        {
            InitializeComponent();
            primljeniZaposleni = primljeni;
        }

        private void BazaPodataka_Load(object sender, EventArgs e)
        {
            /*
            PrijavljeniKorisnikTextBox.Text = primljeniZaposleni.Ime + " " + primljeniZaposleni.Prezime;
            UlogaLabel.Text = primljeniZaposleni.Uloga;
            */
            OsvjeziListu();
        }

        private void OdjavaLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void OsvjeziListu()
        {
            Database.Instance.Connect();
            dataGridView1.DataSource = null;
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

                Zaposlenici trenutniZaposlenik = new Zaposlenici(id,  oib,  ime,  prezime)
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
            dataGridView1.DataSource = listaSvih;
            Database.Instance.Disconnect();

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zaposlenici odabraniZaposlenik = dataGridView1.CurrentRow.DataBoundItem as Zaposlenici;
            DialogResult odabir = MessageBox.Show("Obrisi odabranog korisnika", "POTVRDA", MessageBoxButtons.YesNo);
            if(odabir == DialogResult.Yes)
            {
                ObrisiKorisnika(odabraniZaposlenik);
            }
        }
        private void ObrisiKorisnika(Zaposlenici odabraniZaposlenik)
        {
            Database.Instance.Connect();
            string SQLComanda = "DELETE FROM Zaposlenici WHERE IDKorisnika=" + odabraniZaposlenik.IDKorisnika;
            Database.Instance.ExecuteCommand(SQLComanda);
            Database.Instance.Disconnect();
            OsvjeziListu();
            PrikaziObavijest("Uspjesno sam obrisao korinsika", "OBRISANO", System.Drawing.SystemIcons.Asterisk);
        }
        private void PrikaziObavijest(string pogreska, string vrstaPogreske, System.Drawing.Icon obavijest)
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.BalloonTipText = vrstaPogreske;
            notifyIcon.BalloonTipTitle = pogreska;
            notifyIcon.Icon = obavijest;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(5000);
            Thread.Sleep(3000);
            notifyIcon.Dispose();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DodajKorisnika dodajKorisnika = new DodajKorisnika();
            dodajKorisnika.ShowDialog();
            
            OsvjeziListu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zaposlenici odabraniZaposlenik = dataGridView1.CurrentRow.DataBoundItem as Zaposlenici;
            DodajKorisnika izmjeniKorisnik = new DodajKorisnika(odabraniZaposlenik);
            izmjeniKorisnik.ShowDialog();
            OsvjeziListu();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
