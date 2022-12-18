using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DodajAranzman.xaml
    /// </summary>
    public partial class DodajAranzman : Window
    {
        private Korisnik korisnik;
        private BitmapImage slika= new BitmapImage();
        public DodajAranzman(Korisnik korisnik)
        {
            this.korisnik = korisnik;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(korisnik!=null)
            {
                DbUtil.dodajAranzman(korisnik,GradBox.Text,DrzavaBox.Text,OpisBox.Text,PolazakBox.Text,PovratakBox.Text,CijenaBox.Text,MjestaBox.Text,slika);
            }
            new Zaposleni(korisnik).Show();
            Close();
        }

        private void DodajSliku_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
             "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
             "Portable Network Graphic (*.png)|*.png"
            };
            if (op.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(op.FileName));
                slika = image;
                imagePanel.Children.Clear();
                Image image1 = new Image();
                image1.Source = image;
                image1.Height = 230;

                imagePanel.Children.Add(image1);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            new Zaposleni(korisnik).Show();
        }
    }
}
