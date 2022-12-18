using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelAgencyWpfHci.Model;

namespace TravelAgencyWpfHci.view
{
    /// <summary>
    /// Interaction logic for AranzmanDetaljnoKupac.xaml
    /// </summary>
    public partial class AranzmanDetaljnoKupac : Window
    {
        private Aranzman aranzman;
        private Korisnik korisnik;
        public AranzmanDetaljnoKupac(Aranzman aranzman,Korisnik korisnik)
        {
            InitializeComponent();
            this.aranzman = aranzman;
            this.korisnik = korisnik;
            setItems();
        }

        private void KupiButton_Click(object sender, RoutedEventArgs e)
        {
            new KupacKupovina(aranzman,korisnik).Show();
            Close();
        }

        private void RezervisiButton_Click(object sender, RoutedEventArgs e)
        {
            new KupacRezervacija(aranzman,korisnik).Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Kupac(korisnik).Show();
            Close();
        }
        public void setItems()
        {
            SlikaAranzmana.Source = aranzman.Slika;
            GradBox.Text = aranzman.Grad;
            DrzavaBox.Text = aranzman.Naziv_drzave;
            if (aranzman.Opis.Length < 50)
            {
                OpisBox.Height = 28;
            }
            else if (aranzman.Opis.Length > 50 && aranzman.Opis.Length < 200)
            {
                OpisBox.Height = 55;
            }
            OpisBox.Text = aranzman.Opis;
            DatumPolaskaBox.Text = aranzman.Datum_polaska.ToString("MM/dd/yyyy");
            DatumPovratkaBox.Text = aranzman.Datum_povratka.ToString("MM/dd/yyyy");
            CijenaBox.Text = aranzman.Cijena.ToString();
            MjestaBox.Text = aranzman.Broj_mjesta.ToString();
            GradBox.IsEnabled = true;
            GradBox.IsReadOnly = true;
            DrzavaBox.IsEnabled = true;
            DrzavaBox.IsReadOnly = true;
            OpisBox.IsEnabled = true;
            OpisBox.IsReadOnly = true;
            DatumPolaskaBox.IsEnabled = false;
            DatumPovratkaBox.IsEnabled = false;
            CijenaBox.IsEnabled = true;
            CijenaBox.IsReadOnly = true;
            MjestaBox.IsEnabled = true;
            MjestaBox.IsReadOnly = true;

        }
    }
}
