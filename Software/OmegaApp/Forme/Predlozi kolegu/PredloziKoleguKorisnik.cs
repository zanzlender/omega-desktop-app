using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Omega.Klase;
using System.Diagnostics;
using System.IO;

namespace Omega
{
    public partial class PredloziKoleguKorisnik : Form
    {
        public PredloziKoleguKorisnik()
        {
            InitializeComponent();
        }

        private void PocetnaKorisnik_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(PocetnaKorisnik_KeyDown);

            //TODO: dohvati podatke iz baze za comboboxove

            DohvatiCombo();
        }

        private void DohvatiCombo()
        {
            List<TipPrijave> tipPrijave;
            List<RadnoMjesto> radnoMjesto;
            List<Natjecaj> natjecaj;

            using (var context = new PI20_008_DBEntities2())
            {
                tipPrijave = context.TipPrijave.ToList();
                radnoMjesto = context.RadnoMjesto.ToList();
                natjecaj = context.Natjecaj.ToList();
            }
            comboBoxTipPrijave.DataSource = tipPrijave;
            comboBoxRadnoMjesto.DataSource = radnoMjesto;
            comboBoxNatjecaj.DataSource = natjecaj;

            comboBoxTipPrijave.ResetText();
            comboBoxTipPrijave.SelectedIndex = -1;
            comboBoxRadnoMjesto.ResetText();
            comboBoxRadnoMjesto.SelectedIndex = -1;
            comboBoxNatjecaj.ResetText();
            comboBoxNatjecaj.SelectedIndex = -1;


            /*List<TipPrijave> tipPrijave;
            List<RadnoMjesto> radnoMjesto;
            List<Natjecaj> natjecaj;
            using (var context = new PI20_008_DBEntities())
            {
                tipPrijave = context.TipPrijave.ToList();
                radnoMjesto = context.RadnoMjesto.ToList();
                natjecaj = context.Natjecaj.ToList();
            }

            comboBoxTipPrijave.DataSource = tipPrijave;
            comboBoxRadnoMjesto.DataSource = radnoMjesto;
            comboBoxNatjecaj.DataSource = natjecaj;*/
        }

        private void LogOutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void PocetnaKorisnik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                byte[] PDF = OmegaApp.Properties.Resources.Tehnicka_doukmenija_OMEGA;
                MemoryStream ms = new MemoryStream(PDF);
                FileStream file = new FileStream("help.pdf", FileMode.OpenOrCreate);
                ms.WriteTo(file);
                file.Close();
                ms.Close();
                Process.Start("help.pdf");
            }
        }



        private void PredloziKoleguKorisnik_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }



        private void buttonOdaberiDatoteku_Click(object sender, EventArgs e)
        {
            openFileDialogZivotopis = new OpenFileDialog();
            openFileDialogZivotopis.Filter = "Pdf files | *.pdf";
            openFileDialogZivotopis.Multiselect = false;
            var jelOK = openFileDialogZivotopis.ShowDialog();

            if (jelOK == DialogResult.OK)
            {
                String putanja = openFileDialogZivotopis.FileName;
                //byte[] zapisUbitovima = File.ReadAllBytes(putanja); //datoteka spremljena u byte arrayu. na submit cu ju prenjeti u tablicu
                labelOdabranaDatoteka.Text = putanja;
            }

        }


        private void PobrisiPolja()
        {
            textBoxIme.Text = "";
            textBoxPrezime.Text = "";
            textBoxEmail.Text = "";
            textBoxTelefonskiBroj.Text = "";
            textBoxAdresa.Text = "";
            textBoxDrustvenaMreza.Text = "";
            textBoxPismoZamolbe.Text = "";
            comboBoxTipPrijave.ResetText();
            comboBoxTipPrijave.SelectedIndex = -1;
            comboBoxRadnoMjesto.ResetText();
            comboBoxRadnoMjesto.SelectedIndex = -1;
            comboBoxNatjecaj.ResetText();
            comboBoxNatjecaj.SelectedIndex = -1;
            openFileDialogZivotopis.FileName = null;
            labelOdabranaDatoteka.Text = null;
        }



        private void buttonPosalji_Click_1(object sender, EventArgs e)
        {
            if (textBoxIme.Text == "" || textBoxPrezime.Text == "" || textBoxEmail.Text == "" || textBoxTelefonskiBroj.Text == "" || textBoxAdresa.Text == "" || openFileDialogZivotopis.FileName == "" || comboBoxTipPrijave.SelectedIndex == -1 || comboBoxRadnoMjesto.SelectedIndex == -1 || comboBoxNatjecaj.SelectedIndex == -1)
            {
                MessageBox.Show("Niste unjeli obavezna polja označena sa *");
                return;
            }
            else
            {

                string putanja = openFileDialogZivotopis.FileName;


                using (var context = new PI20_008_DBEntities2())
                {


                    TipPrijave tip = comboBoxTipPrijave.SelectedItem as TipPrijave;
                    var query = from t in context.TipPrijave
                                where t.ID == tip.ID
                                select t.ID;
                    int idPrijava = query.First();

                    RadnoMjesto radnomj = comboBoxRadnoMjesto.SelectedItem as RadnoMjesto;
                    var query2 = from r in context.RadnoMjesto
                                 where r.ID == radnomj.ID
                                 select r.ID;
                    int idRadnomj = query2.First();


                    Natjecaj natjecaj = comboBoxNatjecaj.SelectedItem as Natjecaj;
                    var query3 = from n in context.Natjecaj
                                 where n.ID == natjecaj.ID
                                 select n.ID;
                    int idNatjecaj = query3.First();

                    PredloziKolegu posaljiOvo = new PredloziKolegu
                    {
                        Ime = textBoxIme.Text,
                        Prezime = textBoxPrezime.Text,
                        Email = textBoxEmail.Text,
                        TelefonskiBroj = textBoxTelefonskiBroj.Text,
                        Adresa = textBoxAdresa.Text,
                        DrustvenaMreza = textBoxDrustvenaMreza.Text,
                        PismoZamolbe = textBoxPismoZamolbe.Text,
                        Zivotopis = File.ReadAllBytes(putanja),
                        IDTipPrijave = idPrijava,
                        IDRadnoMjesto = idRadnomj,
                        IDNatjecaj = idNatjecaj
                    };
                    context.PredloziKolegu.Add(posaljiOvo);
                    context.SaveChanges();
                    //OsvjeziDgv();
                }
                //nakon slanja pocistiti polja
                PobrisiPolja();
                MessageBox.Show("Poslano.");
            }
        }

        private void buttonPobrisi_Click_1(object sender, EventArgs e)
        {
            PobrisiPolja();
        }
    }
}
