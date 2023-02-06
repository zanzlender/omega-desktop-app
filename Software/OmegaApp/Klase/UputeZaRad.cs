using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Klase
{
    class UputeZaRad
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public string Objavio { get; set; }
        byte[] DirektorijDatoteke { get; set; }
        public string FAQPitanje { get; set; }
        public string FAQOdgovor { get; set; }

        public UputeZaRad(string naziv, byte[] URL, DateTime DatumObjave, string objavio)
        {
            this.Naziv = naziv;
            this.DirektorijDatoteke = URL;
            this.Datum = DatumObjave;
            this.Objavio = objavio;
        }

        public UputeZaRad(string Pitanje, string Odgovor)
        {
            this.FAQPitanje = Pitanje;
            this.FAQOdgovor = Odgovor;
        }
    }
}
