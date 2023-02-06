using Generiraj;
using OmegaApp.Forme.BazaPodataka;
using OmegaApp.LogIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Forms;

namespace OmegaApp.Forme.Home
{
    public partial class HomeForm : Form
    {
        Zaposlenici prijavljeniZaposlenik;
        /// <summary>
        /// Konstruktor koji 
        /// Kao parametar prima "primljeni" tipa Zaposlenici koji se proslijeđuje iz Log in forme i DLLa 
        /// Dohvaćaju sve podatke zaposlenika i spremaju u varijablu prijavljeniZaposlenik
        /// </summary>
        /// <param name="primljeni"></param>
        public HomeForm(Zaposlenici primljeni)
        {
            InitializeComponent();
            prijavljeniZaposlenik = primljeni;
            
            back = new Bitmap(".\\Resources\\Slike\\back.png");
            hour = new Bitmap(".\\Resources\\Slike\\hour.png");
            minute = new Bitmap(".\\Resources\\Slike\\minute.png");
            dot = new Bitmap(".\\Resources\\Slike\\dot.png");
            second = new Bitmap(".\\Resources\\Slike\\second.png");
        }

        
        /// <summary>
        /// Metoda se izvršava prilikom učitavanja glavne, Parent, forme 
        /// Kao parametre prima "sender" i "e" on load akciju
        /// Postavljaju se Ime, Prezime i Uloga prijavljenog korisnika u definira TextBox-eve
        /// Ako je prijavljeni korisnik "Administrator" dodatno ima mogućnost vidjeti opciju u izborniku Baza zaposlenika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeForm_Load(object sender, EventArgs e)
        {
            PrijavljeniKorisnikTextBox.Text = prijavljeniZaposlenik.Ime + " " + prijavljeniZaposlenik.Prezime;
            UlogaLabel.Text = prijavljeniZaposlenik.Uloga;

            if(prijavljeniZaposlenik.Uloga == "Administrator")
            {
                btnBazaPodataka.Visible = true;
                btnBazaPodataka.Enabled = true;
            }
            else
            {
                btnBazaPodataka.Visible = false;
                btnBazaPodataka.Enabled = false;
            }
        }
        
        public Form activeForm = null;
        /// <summary>
        /// Metoda kojom se otvaraju Child forme unutar Parent forme HomeForm
        /// Kao parametre prima childForm tipa Form, odnosno formu koju želimo otvoriti kao Child formu
        /// Ukoliko je neka druga Child forma otvorena zatvara ju i umjesto nje postavlja novu
        /// </summary>
        /// <param name="childForm"></param>
        public void openChildForm(Form childForm)
        {
            panelClockParent.Visible = false;
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            panel4.Visible = false;
            panel4.Enabled = false;
            panelClockParent.Visible = false;
            panelClockParent.Enabled = false;
        }

        /// <summary>
        /// Metoda koja se poziva klikom na gumb Help
        /// Kao parametre prima "sender" gumb Help i "e" on click akciju
        /// Otvara CHM datoteku Uputa za rad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://" + Environment.CurrentDirectory + "\\Helps.chm");
        }

        

    #region Gumbovi izbornika
        /// <summary>
        /// Sve metode u regiji predstavljaju On click action za gumbove izbornika.
        /// Kao parametre primaju "sender" koji predstavlja gumb i "e" koji predstavlja klik akciju.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovosti_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "NOVOSTI I OBAVIJESTI";
            openChildForm(new Novosti.Novosti());
        }

        private void btnPutniNalozi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "PUTNI NALOZI";
            openChildForm(new Putni_nalozi.putniNalozi());
        }

        private void btnRezervacijaAutomobila_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "REZERVACIJA AUTOMOBILA";
            openChildForm(new Rezervacija_automobila.rezervacijaAutomobila());
        }

        private void btnGodisnjiOdmori_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "GODIŠNJI ODMORI";
            openChildForm(new Godisnji_odmor.godisnjiOdmor());
        }

        private void btnPrijavaInovacija_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "PRIJAVA INOVACIJA";
            openChildForm(new Prijava_inovacija.prijavaInovacije());
        }

        private void btnPrijavaPoteskoca_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "PRIJAVA POTEŠKOĆA U RADU";
            openChildForm(new Prijava_poteskoca.prijavaPoteskoca());
        }

        private void btnUpute_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "UPUTE ZA RAD";
            openChildForm(new Omega.frmUputeZaRad(prijavljeniZaposlenik));
        }

        private void btnPredloziKolegu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "PREDLOŽI KOLEGU ZA OMEGU";
            if(prijavljeniZaposlenik.Uloga == "Administrator")
            {
                openChildForm(new Omega.PredloziKoleguAdmin());
            }
            else
            {
                openChildForm(new Omega.PredloziKoleguKorisnik());
            }
        }

        private void btnTrznica_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "TRŽNICA";
            openChildForm(new Trznica.Trznica());
        }

        private void btnDolasci_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "DOLASCI";
            openChildForm(new Dolasci.Dolasci());
        }

        private void btnOdlasci_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "ODLASCI";
            openChildForm(new Odlasci.Odlasci());
        }

        private void btnRazvojZaposlenika_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "RAZVOJ ZAPOSLENIKA";
            openChildForm(new Razvoj_zaposlenika.razvojZaposlenika());
        }

        private void btnBazaPodataka_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            txtNaslovStranice.Text = "BAZA ZAPOSLENIKA";
            openChildForm(new BazaPodataka.BazaPodataka(prijavljeniZaposlenik));
        }
    #endregion
        
        /// <summary>
        /// Metoda se poziva klikom na gumb ODJAVA
        /// Kao parametre prima "sender" gumb ODJAVA i "e" on click akciju
        /// Otvara se MessageBox i pita se korisnika da li se stvarno želi odjaviti, ukoliko klikne DA, vraća se na prijavu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult odjava = MessageBox.Show("Jeste li sigurni da se želite odjaviti?", "Odjavi me", MessageBoxButtons.YesNo);
            if (odjava == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Struktura u kojoj su pohranjene u varijablama RGB vrijednosti korištenih boja
        /// </summary>
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(2, 88, 159);
        }


    #region Animacija gumbova izbornika

        private IconButton currentBtn;

        /// <summary>
        /// Metoda mijenja boju i padding gumba čije parametre prima, koristi se za gumbove u izborniku.
        /// Kao parametre prima "senderBtn" odnosno gumb i "e" on click akciju
        /// Mijenja boju teksta gumba u color i postavlja padding lijevo na 30
        /// </summary>
        /// <param name="senderBtn"></param>
        /// <param name="color"></param>
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                currentBtn.Padding = new Padding(30,0,0,0);
            }
        }
        /// <summary>
        /// Metoda mijenja boju i padding
        /// Koristi se da bi se poništile promjene izvršene metodom ActivateButton
        /// </summary>
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.ForeColor = Color.Gray;
                currentBtn.IconColor = Color.Gray;
                currentBtn.Padding = new Padding(18, 0, 0, 0);
            }
        }
    #endregion

        /// <summary>
        /// Metoda se izvršava kada se klikne na Logo sliku u izborniku.
        /// Kao parametre prima "sender" sliku i "e" on click akciju
        /// Ako postoji aktivna Child forma zatvara ju, odnosno vraća nas na Home.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureHomeLogo_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                activeForm.Close();
                DisableButton();
            }
            txtNaslovStranice.Text = "";
            panelClockParent.Visible = true;
            panelClockParent.Enabled = true;
            panel4.Visible = true;
            panel4.Enabled = true;
        }

        
    #region Home forma sat

        Bitmap back, hour, minute, dot, second;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            int Hour = Now.Hour;
            int Minute = Now.Minute;
            int Second = Now.Second;

            Single AngleS = Second * 6;
            Single AngleM = Minute * 6 + AngleS / 60;
            Single AngleH = Hour * 30 + AngleM / 12;

            BackBox.Image = back;

            BackBox.Controls.Add(HourBox);
            HourBox.Location = new Point(0, 0);
            HourBox.Image = rotateImage(hour, AngleH);


            HourBox.Controls.Add(MinuteBox2);
            MinuteBox2.Location = new Point(0, 0);
            MinuteBox2.Image = rotateImage(minute, AngleM);

            MinuteBox2.Controls.Add(DotBox);
            DotBox.Location = new Point(0, 0);
            DotBox.Image = dot;

            DotBox.Controls.Add(SecondBox);
            SecondBox.Location = new Point(0, 0);
            SecondBox.Image = rotateImage(second, AngleS);
        }
        private Bitmap rotateImage(Bitmap rotateMe, float angle)
        {
            Bitmap rotatedImage = new Bitmap(rotateMe.Width, rotateMe.Height);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform(rotateMe.Width / 2, rotateMe.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-rotateMe.Width / 2, -rotateMe.Height / 2);
                g.DrawImage(rotateMe, new Point(0, 0));
            }
            return rotatedImage;
        }
    #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
