using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyWpfHci.Model
{
    public class Korisnik
    {
        private string jmbg;
        private string ime;
        private string prezime;
        private string broj_telefona;
        private string email;
        private DateTime datum_rodjenja;
        private string korisnicko_ime;
        private string lozinka;
        private int tema;
        private int rola;

        public Korisnik()
        {

        }

        public Korisnik(string jmbg, string ime, string prezime, string broj_telefona, string email, DateTime datum_rodjenja, string korisnicko_ime, string lozinka, int tema, int rola)
        {
            this.Jmbg = jmbg;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Broj_telefona = broj_telefona;
            this.Email = email;
            this.Datum_rodjenja = datum_rodjenja;
            this.Korisnicko_ime = korisnicko_ime;
            this.Lozinka = lozinka;
            this.Tema = tema;
            this.Rola = rola;
        }

        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Broj_telefona { get => broj_telefona; set => broj_telefona = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Datum_rodjenja { get => datum_rodjenja; set => datum_rodjenja = value; }
        public string Korisnicko_ime { get => korisnicko_ime; set => korisnicko_ime = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public int Tema { get => tema; set => tema = value; }
        public int Rola { get => rola; set => rola = value; }

        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnik &&
                   Jmbg == korisnik.Jmbg;
        }

        public override int GetHashCode()
        {
            return 335871579 + EqualityComparer<string>.Default.GetHashCode(Jmbg);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
