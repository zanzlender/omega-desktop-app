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
using System.Data.Entity.Validation;
using Generiraj;

namespace Omega
{
    public partial class frmUputeZaRad : Form
    {
        Zaposlenici pKorisnik;
        string PrijavljeniKorisnik;
        string Uloga;
        public frmUputeZaRad(Zaposlenici prijavljeniZaposlenik)
        {
            PrijavljeniKorisnik = prijavljeniZaposlenik.Ime + " " + prijavljeniZaposlenik.Prezime;
            Uloga = prijavljeniZaposlenik.Uloga;
            pKorisnik = prijavljeniZaposlenik;
            InitializeComponent();
        }

        private void PocetnaKorisnik_Load(object sender, EventArgs e)
        {
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void prijedlogLabel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Uloga == "Korisnik")
            {
                PredloziKoleguKorisnik predloziKoleguKorisnik = new PredloziKoleguKorisnik();
                predloziKoleguKorisnik.Show();
            }
            else if (Uloga == "Administrator")
            {
                PredloziKoleguAdmin predloziKoleguAdmin = new PredloziKoleguAdmin();
                predloziKoleguAdmin.Show();
            }
            else
            {
                MessageBox.Show("Defenzivni else. Negdje je bug. Nije trebalo doci do ovdje.");
            }

            
        }

        private void txtboxUputeZaRadNaslov_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUputeZaRadOpcenito_Click(object sender, EventArgs e)
        {
            SakrijSve();
            panelNaslovOpcenito.Visible=true;
            PanelOpcenito.Visible=true;
            if (Uloga == "Administrator")
            {
                panelUputeZaRadOpcenitoAdmin.Visible=true;
                panelStrateskiAdmin.Visible = true;
            }
            OsvjeziOpcenito();
        }

        private void btnOpcenitoDodaj_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        public void OsvjeziOpcenito()
        {
            
            using (var context = new PI20_008_DBEntities2())
            {
                dgvOpcenitoPravilnici.DataSource = null;
                dgvOpcenitoPravilnici.Columns.Clear();
                dgvOpcenitoPravilnici.DataSource = context.UputeZaRad.ToList();
                dgvOpcenitoPravilnici.Columns["URL"].Visible = false;
                dgvOpcenitoPravilnici.Columns["UputeZaRadID"].Visible = false;
                DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
                Image image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "Resources\\Icons\\icon.jpeg");
                imgcol.Image = image;
                dgvOpcenitoPravilnici.Columns.Add(imgcol);

                dgvStrateskiDokumenti.DataSource = null;
                dgvStrateskiDokumenti.Columns.Clear();
                dgvStrateskiDokumenti.DataSource = context.StrateskiDokumenti.ToList();
                dgvStrateskiDokumenti.Columns["URL"].Visible = false;
                dgvStrateskiDokumenti.Columns["StrateskiDokumentID"].Visible = false;
                DataGridViewImageColumn imgcol2 = new DataGridViewImageColumn();
                Image image2 = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "Resources\\Icons\\icon.jpeg");
                imgcol2.Image = image;
                dgvStrateskiDokumenti.Columns.Add(imgcol2);
            }
        }

        private void btnOpcenitoObrisi_Click(object sender, EventArgs e)
        {
            DialogResult sigurnost = MessageBox.Show("Jeste li sigurni?", "Sigurnost", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            UputeZaRad odabrani = dgvOpcenitoPravilnici.CurrentRow.DataBoundItem as UputeZaRad;
            using (var context = new PI20_008_DBEntities2())
            {
                if (odabrani != null && sigurnost == DialogResult.Yes)
                {
                    context.UputeZaRad.Attach(odabrani);
                    context.UputeZaRad.Remove(odabrani);
                    context.SaveChanges();
                    MessageBox.Show("Dokument je izbrisan!", "OBRISAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OsvjeziOpcenito();
                }
            }
        }

        private void dgvOpcenitoPravilnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOpcenitoPravilnici.CurrentCell.ColumnIndex.Equals(5))
            {
                UputeZaRad OdabranaUputa = dgvOpcenitoPravilnici.CurrentRow.DataBoundItem as UputeZaRad;
                byte[] array = OdabranaUputa.URL;

                if (OdabranaUputa.URL != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save .pdf";
                    saveFileDialog.Filter = "PDF Files (*.pdf) | *.pdf";
                    saveFileDialog.FileName = OdabranaUputa.Naziv + ".pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, array);
                    }
                }
            }
        }

        private void SakrijSve()
        {
            panelNaslovOpcenito.Visible = false;
            panelNaslovObrasci.Visible = false;
            panelNaslovFAQ.Visible = false;

            PanelOpcenito.Visible=false;
            panelObrasci.Visible = false;
            panelFAQ.Visible = false;

            panelUputeZaRadOpcenitoAdmin.Visible=false;
            panelObrasciAdmin.Visible = false;
            panelFAQAdmin.Visible = false;
        }

        private void btnUputeZaRadObrasci_Click(object sender, EventArgs e)
        {
            SakrijSve();
            panelNaslovObrasci.Visible = true;
            panelObrasci.Visible=true;
            if (Uloga == "Administrator")
            {
                panelObrasciAdmin.Visible = true;
            }
            OsvjeziObrasce();
        }

        private void OsvjeziObrasce()
        {
            using (var context = new PI20_008_DBEntities2())
            {
                dgvUputeZaRadObrasci.DataSource = null;
                dgvUputeZaRadObrasci.Columns.Clear();
                dgvUputeZaRadObrasci.DataSource = context.Obrasci.ToList();
                dgvUputeZaRadObrasci.Columns["URL"].Visible = false;
                dgvUputeZaRadObrasci.Columns["ObrazacID"].Visible = false;
                DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
                Image image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "Resources\\Icons\\icon.jpeg");
                imgcol.Image = image;
                dgvUputeZaRadObrasci.Columns.Add(imgcol);

                
            }
        }

        private void dgvUputeZaRadObrasci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUputeZaRadObrasci.CurrentCell.ColumnIndex.Equals(5))
            {
                Obrasci obrazac = dgvUputeZaRadObrasci.CurrentRow.DataBoundItem as Obrasci;
                byte[] array = obrazac.URL;

                if (obrazac.URL != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save .pdf";
                    saveFileDialog.Filter = "PDF Files (*.pdf) | *.pdf";
                    saveFileDialog.FileName = obrazac.Naziv + ".pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, array);
                    }
                }
            }
        }

        private void btnObrasciDodaj_Click(object sender, EventArgs e)
        {
            string putanja = openFileDialogObrazac.FileName;

            if (txtboxNazivObrasca.Text != "")
            {
                try
                {
                    using (var context = new PI20_008_DBEntities2())
                    {
                        Obrasci obrazac = new Obrasci
                        {
                            Naziv = txtboxNazivObrasca.Text,
                            URL = File.ReadAllBytes(putanja),
                            Datum = DateTime.Now,
                            Objavio = PrijavljeniKorisnik,
                        };
                        context.Obrasci.Add(obrazac);
                        context.SaveChanges();
                    }
                    //nakon slanja pocistiti polja
                    txtboxNazivObrasca.Text = "";
                    openFileDialogObrazac.FileName = null;
                    MessageBox.Show("Poslano.");
                }
                catch(DbEntityValidationException d)
                {
                    foreach (var eve in d.EntityValidationErrors)
                    {
                        MessageBox.Show($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Potrebno je upisati naziv dokumenta.");
            }
        }

        private void btnObrasciOdaberiDatoteku_Click(object sender, EventArgs e)
        {
            openFileDialogObrazac = new OpenFileDialog();
            openFileDialogObrazac.Filter = "Pdf files | *.pdf";
            openFileDialogObrazac.Multiselect = false;
            var jelOK = openFileDialogObrazac.ShowDialog();

            if (jelOK == DialogResult.OK)
            {
                String putanja = openFileDialogObrazac.FileName;
                byte[] zapisUbitovima = File.ReadAllBytes(putanja); //datoteka spremljena u byte arrayu. na submit cu ju prenjeti u tablicu
                openFileDialogObrazac.FileName = putanja;

            }
        }

        private void btnObrasciObrisi_Click(object sender, EventArgs e)
        {
            DialogResult sigurnost = MessageBox.Show("Jeste li sigurni?", "Sigurnost", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            Obrasci odabrani = dgvUputeZaRadObrasci.CurrentRow.DataBoundItem as Obrasci;
            using (var context = new PI20_008_DBEntities2())
            {
                if (odabrani != null && sigurnost == DialogResult.Yes)
                {
                    context.Obrasci.Attach(odabrani);
                    context.Obrasci.Remove(odabrani);
                    context.SaveChanges();
                    MessageBox.Show("Dokument je izbrisan!", "OBRISAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OsvjeziObrasce();
                }
            }
        }

        private void btnDodajStrateski_Click(object sender, EventArgs e)
        {
            string putanja = openFileDialogObrazac.FileName;

            if (txtboxNazivStrateskog.Text != "")
            {
                try
                {
                    using (var context = new PI20_008_DBEntities2())
                    {
                        StrateskiDokumenti strateski = new StrateskiDokumenti
                        {
                            Naziv = txtboxNazivStrateskog.Text,
                            URL = File.ReadAllBytes(putanja),
                            Datum = DateTime.Now,
                            Objavio = PrijavljeniKorisnik,
                        };
                        context.StrateskiDokumenti.Add(strateski);
                        context.SaveChanges();
                    }
                    //nakon slanja pocistiti polja
                    txtboxNazivStrateskog.Text = "";
                    openFileDialogObrazac.FileName = null;
                    MessageBox.Show("Poslano.");
                    OsvjeziOpcenito();
                }
                catch (DbEntityValidationException d)
                {
                    foreach (var eve in d.EntityValidationErrors)
                    {
                        MessageBox.Show($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Potrebno je upisati naziv dokumenta.");
            }
        }

        private void btnOdaberiDatotekuStrateski_Click(object sender, EventArgs e)
        {
            openFileDialogObrazac = new OpenFileDialog();
            openFileDialogObrazac.Filter = "Pdf files | *.pdf";
            openFileDialogObrazac.Multiselect = false;
            var jelOK = openFileDialogObrazac.ShowDialog();

            if (jelOK == DialogResult.OK)
            {
                String putanja = openFileDialogObrazac.FileName;
                byte[] zapisUbitovima = File.ReadAllBytes(putanja); //datoteka spremljena u byte arrayu. na submit cu ju prenjeti u tablicu
                openFileDialogObrazac.FileName = putanja;

            }
        }

        private void btnIzbrisiStrateski_Click(object sender, EventArgs e)
        {
            DialogResult sigurnost = MessageBox.Show("Jeste li sigurni?", "Sigurnost", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            StrateskiDokumenti odabrani = dgvStrateskiDokumenti.CurrentRow.DataBoundItem as StrateskiDokumenti;
            using (var context = new PI20_008_DBEntities2())
            {
                if (odabrani != null && sigurnost == DialogResult.Yes)
                {
                    context.StrateskiDokumenti.Attach(odabrani);
                    context.StrateskiDokumenti.Remove(odabrani);
                    context.SaveChanges();
                    MessageBox.Show("Dokument je izbrisan!", "OBRISAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OsvjeziOpcenito();
                }
            }
        }

        private void btnUputeZaRadFAQ_Click(object sender, EventArgs e)
        {
            SakrijSve();
            panelFAQ.Visible = true;
            panelNaslovFAQ.Visible = true;
            if (Uloga == "Administrator")
            {
                panelFAQAdmin.Visible = true;
            }
            OsvjeziFAQ();
        }

        private void OsvjeziFAQ()
        {
            using (var context = new PI20_008_DBEntities2())
            {
                dgvFAQ.DataSource = null;
                dgvFAQ.Columns.Clear();
                dgvFAQ.DataSource = context.FAQ.ToList();
                dgvFAQ.Columns["FAQID"].Visible = false;
                
            }
        }

        private void btnFAQDodaj_Click(object sender, EventArgs e)
        {
            

            if (txtboxFAQPitanje.Text != "" && txtboxFAQOdgovor.Text != "")
            {
                using (var context = new PI20_008_DBEntities2())
                {
                    FAQ Faq = new FAQ
                    {
                        Pitanje = txtboxFAQPitanje.Text,
                        Odgovor = txtboxFAQOdgovor.Text
                    };
                    context.FAQ.Add(Faq);
                    context.SaveChanges();
                }
                //nakon slanja pocistiti polja
                txtboxFAQPitanje.Text = "";
                txtboxFAQOdgovor.Text = "";
                MessageBox.Show("Poslano.");
            }
            else
            {
                MessageBox.Show("Potrebno je upisati pitanje i odgovor.");
            }
            OsvjeziFAQ();
        }

        private void btnFAQIzbrisi_Click(object sender, EventArgs e)
        {

            DialogResult sigurnost = MessageBox.Show("Jeste li sigurni?", "Sigurnost", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            FAQ odabrani = dgvFAQ.CurrentRow.DataBoundItem as FAQ;
            if (odabrani != null && sigurnost == DialogResult.Yes)
            {
                using (var context = new PI20_008_DBEntities2())
                {
                    if (sigurnost == DialogResult.Yes)
                    {
                        context.FAQ.Attach(odabrani);
                        context.FAQ.Remove(odabrani);
                        context.SaveChanges();
                        MessageBox.Show("Pitanje je izbrisano!", "OBRISAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OsvjeziFAQ();
                    }
                }
            }
        }

        private void dgvFAQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFAQ.AutoResizeRow(dgvFAQ.CurrentCell.RowIndex, DataGridViewAutoSizeRowMode.AllCells);
        }

        private void dgvStrateskiDokumenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStrateskiDokumenti.CurrentCell.ColumnIndex.Equals(5))
            {
                StrateskiDokumenti strateski = dgvStrateskiDokumenti.CurrentRow.DataBoundItem as StrateskiDokumenti;
                byte[] array = strateski.URL;

                if (strateski.URL != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save .pdf";
                    saveFileDialog.Filter = "PDF Files (*.pdf) | *.pdf";
                    saveFileDialog.FileName = strateski.Naziv + ".pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, array);
                    }
                }
            }
        }

        private void btnDodajOpcenito_Click(object sender, EventArgs e)
        {
            string putanja = openFileDialogObrazac.FileName;

            if (txtboxNazivOpcenito.Text != "")
            {
                try
                {
                    using (var context = new PI20_008_DBEntities2())
                    {
                        UputeZaRad upute = new UputeZaRad
                        {
                            Naziv = txtboxNazivOpcenito.Text,
                            URL = File.ReadAllBytes(putanja),
                            Datum = DateTime.Now,
                            Objavio = PrijavljeniKorisnik,
                        };
                        context.UputeZaRad.Add(upute);
                        context.SaveChanges();
                    }
                    //nakon slanja pocistiti polja
                    txtboxNazivOpcenito.Text = "";
                    openFileDialogObrazac.FileName = null;
                    MessageBox.Show("Poslano.");
                    OsvjeziOpcenito();
                }
                catch (DbEntityValidationException d)
                {
                    foreach (var eve in d.EntityValidationErrors)
                    {
                        MessageBox.Show($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Potrebno je upisati naziv dokumenta.");
            }
        }

        private void btnizbrisiOpcenito_Click(object sender, EventArgs e)
        {
            DialogResult sigurnost = MessageBox.Show("Jeste li sigurni?", "Sigurnost", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            UputeZaRad upute = dgvOpcenitoPravilnici.CurrentRow.DataBoundItem as UputeZaRad;
            using (var context = new PI20_008_DBEntities2())
            {
                if (upute != null && sigurnost == DialogResult.Yes)
                {
                    context.UputeZaRad.Attach(upute);
                    context.UputeZaRad.Remove(upute);
                    context.SaveChanges();
                    MessageBox.Show("Dokument je izbrisan!", "OBRISAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OsvjeziOpcenito();
                }
            }
        }

        private void btnOdaberiDatotekuOpcenito_Click(object sender, EventArgs e)
        {
            openFileDialogObrazac = new OpenFileDialog();
            openFileDialogObrazac.Filter = "Pdf files | *.pdf";
            openFileDialogObrazac.Multiselect = false;
            var jelOK = openFileDialogObrazac.ShowDialog();

            if (jelOK == DialogResult.OK)
            {
                String putanja = openFileDialogObrazac.FileName;
                byte[] zapisUbitovima = File.ReadAllBytes(putanja); //datoteka spremljena u byte arrayu. na submit cu ju prenjeti u tablicu
                openFileDialogObrazac.FileName = putanja;

            }
        }

        private void panelFAQAdmin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
