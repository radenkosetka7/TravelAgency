using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyWpfHci.Model
{
    internal class Grad
    {
        private int idGrada;
        private string nazivGrada;

        public Grad()
        {
        }

        public Grad(int idGrada, string nazivGrada)
        {
            this.IdGrada = idGrada;
            this.NazivGrada = nazivGrada;
        }

        public int IdGrada { get => idGrada; set => idGrada = value; }
        public string NazivGrada { get => nazivGrada; set => nazivGrada = value; }

        public override bool Equals(object obj)
        {
            return obj is Grad grad &&
                   idGrada == grad.idGrada;
        }

        public override int GetHashCode()
        {
            return -232823805 + idGrada.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
