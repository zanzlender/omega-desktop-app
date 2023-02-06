using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generiraj;
using OmegaApp.Forme.Home;
using OmegaApp.Klase;

namespace OmegaApp.LogIn
{
    public partial class LogInForm : Form
    {
        NotifyIcon notifyIcon;
        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            KorisnickoImeTextBox.Text = "";
            LozinkaTextBox.Text = "";
            PrikaziLozinkuCheckBox.Checked = false;
            Database.Instance.Connect();
        }
        private void PrikaziPogresanUnos(string pogreska, string vrstaPogreske, Icon obavijest)
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

        private void PrikaziLozinkuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(PrikaziLozinkuCheckBox.Checked == true)
            {
                LozinkaTextBox.UseSystemPasswordChar = false;
            }
            if(PrikaziLozinkuCheckBox.Checked == false)
            {
                LozinkaTextBox.UseSystemPasswordChar = true;
            }
        }

        private void PrijavaButton_Click(object sender, EventArgs e)
        {
            List<Zaposlenici> listaSvih = VratiSveZaposlenike();
            Zaposlenici prijavaKorisnika = null;
            string trenutniKorisnik = KorisnickoImeTextBox.Text;
            string trenutnaLozinka = LozinkaTextBox.Text;
            bool pronasao = false;

            foreach (var zaposlenik in listaSvih)
            {
                if(zaposlenik.KorisnickoIme == trenutniKorisnik && zaposlenik.Lozinka == trenutnaLozinka)
                {
                    pronasao = true;
                    prijavaKorisnika = zaposlenik;
                    break;
                }
            }
            if(pronasao == true)
            {
                //MessageBox.Show("Uspjesna prijava");
                Database.Instance.Disconnect();
                HomeForm naslovnaForma = new HomeForm(prijavaKorisnika);
                this.Hide();
                naslovnaForma.ShowDialog();
                this.Show();
                Database.Instance.Connect();
                KorisnickoImeTextBox.Text = "";
                LozinkaTextBox.Text = "";
            }
            if(pronasao == false)
            {
                PrikaziPogresanUnos("OMEGA APP", "Krivo uneseni podaci za prijavu!", System.Drawing.SystemIcons.Error);
            }
        }
        private List<Zaposlenici> VratiSveZaposlenike()
        {
            List<Zaposlenici> listaSvih = new List<Zaposlenici>();
            string SQLUpit = "SELECT * FROM Zaposlenici";

            IDataReader citac = Database.Instance.GetDataReader(SQLUpit);

            while(citac.Read())
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
                Zaposlenici trenutniZaposlenik = new Zaposlenici(id, oib, ime, prezime)
                {
                    Email = email,
                    Uloga = uloga,
                    Odjel = odjel,
                    RadnoMjesto = radnoMjesto,
                    KorisnickoIme = korisnckoIme,
                    Lozinka = lozinka
                };
                listaSvih.Add(trenutniZaposlenik);
            }
            citac.Close();
            return listaSvih;
        }
    }
}
