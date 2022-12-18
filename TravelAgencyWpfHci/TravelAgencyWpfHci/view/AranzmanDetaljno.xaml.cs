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
    /// Interaction logic for AranzmanDetaljno.xaml
    /// </summary>
    public partial class AranzmanDetaljno : Window
    {
        private Aranzman aranzman;
        private Korisnik korisnik;
        public AranzmanDetaljno(Aranzman aranzman,Korisnik korisnik)
        {
            InitializeComponent();
            this.aranzman = aranzman;
            this.korisnik = korisnik;
            setItems();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show(FindResource("areyousure") as string,"Warning",MessageBoxButton.YesNo);

            switch(messageBox)
            {
                case MessageBoxResult.Yes:
                    DbUtil.obrisiAranzman(aranzman);
                    new Zaposleni(korisnik).Show();
                    Close();
                    break;
                default:
                    break;
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(korisnik !=null && aranzman != null)
            {
                try
                {
                    DateTime x = DateTime.Parse(DatumPolaskaBox.Text);
                    DateTime y = DateTime.Parse(DatumPovratkaBox.Text);
                    DbUtil.updateAranzman(GradBox.Text, DrzavaBox.Text, x, y, CijenaBox.Text, MjestaBox.Text,aranzman,korisnik);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(FindResource("incorrectinput") as string, "Error");
                }
            }
            new Zaposleni(korisnik).Show();
            Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DatumPolaskaBox.IsEnabled = true;
            DatumPovratkaBox.IsEnabled = true;
            CijenaBox.IsReadOnly = false;
            MjestaBox.IsReadOnly = false;
            SaveButton.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Zaposleni(korisnik).Show();
            Close();
            
        }

        public void setItems()
        {
            SlikaAranzmana.Source = aranzman.Slika;
            GradBox.Text = aranzman.Grad;
            DrzavaBox.Text = aranzman.Naziv_drzave;
            if(aranzman.Opis.Length<50)
            {
                OpisBox.Height=28;
            }
            else if(aranzman.Opis.Length>50 && aranzman.Opis.Length<200)
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
            DeleteButton.IsEnabled = true;

        }
    }
}
