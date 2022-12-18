using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyWpfHci.Model
{
    internal class Drzava
    {
        private int idDrzave;
        private string nazivDrzave;

        public Drzava()
        {
        }

        public Drzava(int idDrzave, string nazivDrzave)
        {
            this.IdDrzave = idDrzave;
            this.NazivDrzave = nazivDrzave;
        }

        public int IdDrzave { get => idDrzave; set => idDrzave = value; }
        public string NazivDrzave { get => nazivDrzave; set => nazivDrzave = value; }

        public override bool Equals(object obj)
        {
            return obj is Drzava drzava &&
                   idDrzave == drzava.idDrzave;
        }

        public override int GetHashCode()
        {
            return 304875966 + idDrzave.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
