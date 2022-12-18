using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyWpfHci.Model
{
    internal class Kupovina
    {
        private int id_aranzmana;
        private int kolicina;
        private string kupac_jmbg;
        private string grad;
        private DateTime datum_polaska;

        public Kupovina()
        {
        }

        public Kupovina(int id_aranzmana, int kolicina, string kupac_jmbg,string grad,DateTime datum_polaska)
        {
            this.Id_aranzmana = id_aranzmana;
            this.Kolicina = kolicina;
            this.Kupac_jmbg = kupac_jmbg;
            this.Grad = grad;
            this.Datum_polaska = datum_polaska;
        }

        public int Id_aranzmana { get => id_aranzmana; set => id_aranzmana = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public string Kupac_jmbg { get => kupac_jmbg; set => kupac_jmbg = value; }
        public string Grad { get => grad; set => grad = value; }
        public DateTime Datum_polaska { get => datum_polaska; set => datum_polaska = value; }

        public override bool Equals(object obj)
        {
            return obj is Kupovina kupovina &&
                   id_aranzmana == kupovina.id_aranzmana;
        }

        public override int GetHashCode()
        {
            return 349231666 + id_aranzmana.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
