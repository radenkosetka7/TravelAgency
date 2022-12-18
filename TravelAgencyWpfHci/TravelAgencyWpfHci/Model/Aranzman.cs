using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TravelAgencyWpfHci.Model
{
    public class Aranzman
    {
        private int id_aranzmana;
        private DateTime datum_polaska;
        private DateTime datum_povratka;
        private decimal cijena;
        private int broj_mjesta;
        private string opis;
        private BitmapImage slika;
        private string naziv_drzave;
        private string grad;
        private int id_destinacije;

        public Aranzman()
        {

        }

        public Aranzman(int id_aranzmana, DateTime datum_polaska, DateTime datum_povratka, decimal cijena, int broj_mjesta, string opis, BitmapImage slika, string naziv_drzave, string grad, int id_destinacije)
        {
            this.Id_aranzmana = id_aranzmana;
            this.Datum_polaska = datum_polaska;
            this.Datum_povratka = datum_povratka;
            this.Cijena = cijena;
            this.Broj_mjesta = broj_mjesta;
            this.Opis = opis;
            this.Slika = slika;
            this.Naziv_drzave = naziv_drzave;
            this.Grad = grad;
            this.Id_destinacije = id_destinacije;
        }

        public int Id_aranzmana { get => id_aranzmana; set => id_aranzmana = value; }
        public DateTime Datum_polaska { get => datum_polaska; set => datum_polaska = value; }
        public DateTime Datum_povratka { get => datum_povratka; set => datum_povratka = value; }
        public decimal Cijena { get => cijena; set => cijena = value; }
        public int Broj_mjesta { get => broj_mjesta; set => broj_mjesta = value; }
        public string Opis { get => opis; set => opis = value; }
        public BitmapImage Slika { get => slika; set => slika = value; }
        public string Naziv_drzave { get => naziv_drzave; set => naziv_drzave = value; }
        public string Grad { get => grad; set => grad = value; }
        public int Id_destinacije { get => id_destinacije; set => id_destinacije = value; }

        public override bool Equals(object obj)
        {
            return obj is Aranzman aranzman &&
                   id_aranzmana == aranzman.id_aranzmana;
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

