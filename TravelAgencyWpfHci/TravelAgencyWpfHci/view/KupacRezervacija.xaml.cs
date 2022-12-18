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
    /// Interaction logic for KupacRezervacija.xaml
    /// </summary>
    public partial class KupacRezervacija : Window
    {
        private Aranzman aranzman;
        private Korisnik korisnik;
        public KupacRezervacija(Aranzman aranzman,Korisnik korisnik)
        {
            InitializeComponent();
            this.aranzman = aranzman;
            this.korisnik = korisnik;
            setItems();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show(FindResource("finishreservation") as string, "Warning", MessageBoxButton.YesNo);

            try
            {
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        DbUtil.dodajRezervaciju(aranzman, korisnik, KolicinaBox.Text, DatumBox.Text);
                        new Kupac(korisnik).Show();
                        Close();
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(FindResource("incorrectinput") as string, "Error");
            }
        }
        public void setItems()
        {
            NazivBox.Text = aranzman.Grad;
            JMBGBox.Text = korisnik.Jmbg;
            DatumBox.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
            NazivBox.IsReadOnly = true;
            JMBGBox.IsReadOnly = true;
            DatumBox.IsEnabled = false;
            KolicinaBox.IsEnabled = true;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            new Kupac(korisnik).Show();
        }
    }
}
