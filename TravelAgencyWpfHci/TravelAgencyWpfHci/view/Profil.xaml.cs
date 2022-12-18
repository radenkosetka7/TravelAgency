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
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        private Korisnik trenutniKorisnik;
        public Profil(Korisnik korisnik)
        {
            InitializeComponent();
            trenutniKorisnik = korisnik;
            setItems();
        }

        public void setItems()
        {
            ImeBox.Text = trenutniKorisnik.Ime;
            PrezimeBox.Text = trenutniKorisnik.Prezime;
            MailBox.Text = trenutniKorisnik.Email;
            TelefonBox.Text = trenutniKorisnik.Broj_telefona;
            DatumBox.Text = trenutniKorisnik.Datum_rodjenja.ToString("MM/dd/yyyy");
            KorisnickoBox.Text = trenutniKorisnik.Korisnicko_ime;
            LozinkaBox.Text = trenutniKorisnik.Lozinka;
            ImeBox.IsEnabled = true;
            ImeBox.IsReadOnly = true;
            PrezimeBox.IsEnabled = true;
            PrezimeBox.IsReadOnly = true;
            MailBox.IsEnabled = true;
            MailBox.IsReadOnly = true;
            TelefonBox.IsEnabled = true;
            TelefonBox.IsReadOnly = true;
            DatumBox.IsEnabled = false;
            KorisnickoBox.IsEnabled = true;
            KorisnickoBox.IsReadOnly = true;
            LozinkaBox.IsEnabled = true;
            LozinkaBox.IsReadOnly = true;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(trenutniKorisnik.Rola==1)
            {
                new Zaposleni(trenutniKorisnik).Show();
                Close();
            }
            else
            {
                new Kupac(trenutniKorisnik).Show();
                Close();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ImeBox.IsReadOnly = false;
            PrezimeBox.IsReadOnly = false;
            MailBox.IsReadOnly = false;
            TelefonBox.IsReadOnly = false;
            DatumBox.IsEnabled = true;
            KorisnickoBox.IsReadOnly = false;
            LozinkaBox.IsReadOnly = false;
            SaveButton.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(trenutniKorisnik != null)
            {
                DateTime x = DateTime.Parse(DatumBox.Text);
                DbUtil.updateKorisnika(ImeBox.Text,PrezimeBox.Text,MailBox.Text,
                    TelefonBox.Text,x,KorisnickoBox.Text,LozinkaBox.Text,trenutniKorisnik);

            }
            trenutniKorisnik=DbUtil.getKorisnik(trenutniKorisnik.Jmbg);
            Button_Click(sender, e);
        }
    }
}
