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
    public partial class PredloziKoleguAdmin : Form
    {
        private List<TipPrijave> tipPrijave;
        private List<RadnoMjesto> radnoMjesto;
        private List<Natjecaj> natjecaj;

        public PredloziKoleguAdmin()
        {
            InitializeComponent();
        }

        private void PocetnaKorisnik_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(PocetnaKorisnik_KeyDown);

            DohvatiCombo();

            OsvjeziDgv();
            
        }

        private void OsvjeziDgv()
        {
            using (var context = new PI20_008_DBEntities2())
            {

                dgvAdminPredlozeni.DataSource = context.PredloziKolegu.ToList();
                //ne radi nista navedeno da se ne selecta redak u dgv
                /*
                dgvAdminPredlozeni.ClearSelection();
                dgvAdminPredlozeni.CurrentCell.Selected = false;
                dgvAdminPredlozeni.CurrentRow.Selected = false;
                dgvAdminPredlozeni.Rows[0].Selected = false;
                dgvAdminPredlozeni.CurrentCell = null;
                //
                */


                dgvAdminPredlozeni.MultiSelect = false;
                dgvAdminPredlozeni.Columns["Natjecaj"].Visible = false;
                dgvAdminPredlozeni.Columns["RadnoMjesto"].Visible = false;
                dgvAdminPredlozeni.Columns["TipPrijave"].Visible = false;
                dgvAdminPredlozeni.Columns["Zivotopis"].Visible = false;
                dgvAdminPredlozeni.Columns["IDNatjecaj"].Visible = false;
                dgvAdminPredlozeni.Columns["IDRadnoMjesto"].Visible = false;
                dgvAdminPredlozeni.Columns["IDTipPrijave"].Visible = false;
                dgvAdminPredlozeni.Columns["PismoZamolbe"].Visible = false;
                dgvAdminPredlozeni.Columns["Adresa"].Visible = false;
                dgvAdminPredlozeni.Columns["DrustvenaMreza"].Visible = false;
                dgvAdminPredlozeni.Columns["TelefonskiBroj"].Visible = false;
                PobrisiPolja();
            }
        }


        private void DohvatiCombo()
        {
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

            /*             
            List<TipPrijave> tipPrijave;
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
            comboBoxNatjecaj.DataSource = natjecaj;
            */
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
                byte[] zapisUbitovima = File.ReadAllBytes(putanja); //datoteka spremljena u byte arrayu. na submit cu ju prenjeti u tablicu
                labelOdabranaDatoteka.Text = putanja;
            }
        }

        private void buttonPobrisi_Click(object sender, EventArgs e)
        {
            PobrisiPolja();
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
            labelOdabranaDatoteka.Text = "";
        }

        private void buttonPosalji_Click(object sender, EventArgs e)
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
                    OsvjeziDgv();
                }
                //nakon slanja pocistiti polja
                PobrisiPolja();
                MessageBox.Show("Poslano.");
            }
        }

        private void buttonAdminDodajTip_Click(object sender, EventArgs e)
        {
            using (var context = new PI20_008_DBEntities2())
            {
                TipPrijave tipPrijave = new TipPrijave
                {
                    Naziv = textBoxAdminDodajTip.Text
                };
                context.TipPrijave.Add(tipPrijave);
                context.SaveChanges();
            }
            DohvatiCombo();
            textBoxAdminDodajTip.Text = "";
            MessageBox.Show("Dodano.");

        }

        private void buttonAdminDodajRadno_Click(object sender, EventArgs e)
        {
            using (var context = new PI20_008_DBEntities2())
            {
                RadnoMjesto radnomj = new RadnoMjesto
                {
                    Naziv = textBoxAdminDodajRadno.Text
                };
                context.RadnoMjesto.Add(radnomj);
                context.SaveChanges();
            }
            DohvatiCombo();
            textBoxAdminDodajRadno.Text = "";
            MessageBox.Show("Dodano.");
        }

        private void buttonAdminDodajNatjecaj_Click(object sender, EventArgs e)
        {
            using (var context = new PI20_008_DBEntities2())
            {
                Natjecaj natjecaj = new Natjecaj
                {
                    Naziv = textBoxAdminDodajNatjecaj.Text
                };
                context.Natjecaj.Add(natjecaj);
                context.SaveChanges();
            }
            DohvatiCombo();
            textBoxAdminDodajNatjecaj.Text = "";
            MessageBox.Show("Dodano.");
        }

        private void buttonAdminObrisiTip_Click(object sender, EventArgs e)
        {
            TipPrijave odabrani = comboBoxTipPrijave.SelectedItem as TipPrijave;

            if (odabrani != null)
            {
                using (var context = new PI20_008_DBEntities2())
                {
                    context.TipPrijave.Attach(odabrani);
                    context.TipPrijave.Remove(odabrani);
                    context.SaveChanges();
                }
                DohvatiCombo();
                MessageBox.Show("Obrisano.");
            }
        }

        private void buttonAdminObrisiRadno_Click(object sender, EventArgs e)
        {
            RadnoMjesto odabrano = comboBoxRadnoMjesto.SelectedItem as RadnoMjesto;

            if (odabrano != null)
            {
                using (var context = new PI20_008_DBEntities2())
                {
                    context.RadnoMjesto.Attach(odabrano);
                    context.RadnoMjesto.Remove(odabrano);
                    context.SaveChanges();
                }
                DohvatiCombo();
                MessageBox.Show("Obrisano.");

            }
        }

        private void buttonAdminObrisiNatjecaj_Click(object sender, EventArgs e)
        {
            Natjecaj odabrani = comboBoxNatjecaj.SelectedItem as Natjecaj;

            if (odabrani != null)
            {
                using (var context = new PI20_008_DBEntities2())
                {
                    context.Natjecaj.Attach(odabrani);
                    context.Natjecaj.Remove(odabrani);
                    context.SaveChanges();
                }
                DohvatiCombo();
                MessageBox.Show("Obrisano.");

            }
        }

        private void dgvAdminPredlozeni_SelectionChanged(object sender, EventArgs e)
        {
            PredloziKolegu odabraniRed = dgvAdminPredlozeni.CurrentRow.DataBoundItem as PredloziKolegu;

            if (odabraniRed != null)
            {
                textBoxIme.Text = odabraniRed.Ime;
                textBoxPrezime.Text = odabraniRed.Prezime;
                textBoxEmail.Text = odabraniRed.Email;
                textBoxTelefonskiBroj.Text = odabraniRed.TelefonskiBroj;
                textBoxAdresa.Text = odabraniRed.Adresa;
                textBoxDrustvenaMreza.Text = odabraniRed.DrustvenaMreza;
                textBoxPismoZamolbe.Text = odabraniRed.PismoZamolbe;


                var tipPrijaveIndex = tipPrijave.FindIndex(x => x.ID == odabraniRed.IDTipPrijave);
                if (tipPrijaveIndex != -1)
                {
                    comboBoxTipPrijave.SelectedIndex = tipPrijaveIndex;
                }

                var radnoMjestoIndex = radnoMjesto.FindIndex(x => x.ID == odabraniRed.IDRadnoMjesto);
                if (radnoMjestoIndex != -1)
                {
                    comboBoxRadnoMjesto.SelectedIndex = radnoMjestoIndex;
                }

                var natjecajIndex = natjecaj.FindIndex(x => x.ID == odabraniRed.IDNatjecaj);
                if (natjecajIndex != -1)
                {
                    comboBoxNatjecaj.SelectedIndex = natjecajIndex;
                }

                if (odabraniRed.Zivotopis != null)
                {
                    buttonAdminPreuzmi.Enabled = true;
                    var zivotopis = odabraniRed.Zivotopis;
                }
                else
                {
                    buttonAdminPreuzmi.Enabled = false;
                }


                //comboBoxTipPrijave.SelectedIndex = comboBoxTipPrijave.FindString(odabraniRed.TipPrijave.Naziv.ToString());
                //comboBoxTipPrijave.SelectedIndex = -1;
                //comboBoxTipPrijave.SelectedText = odabraniRed.TipPrijave.Naziv;
            }
        }

        private void buttonAdminPreuzmi_Click(object sender, EventArgs e)
        {
            PredloziKolegu odabraniRed = dgvAdminPredlozeni.CurrentRow.DataBoundItem as PredloziKolegu;
            byte[] array = odabraniRed.Zivotopis;

            if (odabraniRed.Zivotopis != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save .pdf";
                saveFileDialog.Filter = "PDF Files (*.pdf) | *.pdf";
                saveFileDialog.FileName = odabraniRed.ID + "_" + odabraniRed.Ime + "_" + odabraniRed.Prezime + ".pdf";
                //saveFileDialog.ShowDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, array);
                }
                //FileInfo fi = new FileInfo(saveFileDialog.FileName);

            }
        }

        private void comboBoxNatjecaj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
