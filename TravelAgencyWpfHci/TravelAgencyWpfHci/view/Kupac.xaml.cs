﻿using System;
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
    /// Interaction logic for Kupac.xaml
    /// </summary>
    public partial class Kupac : Window
    {
        public static ResourceDictionary themes
        {
            get { return Application.Current.Resources.MergedDictionaries[4]; }
        }
        public static ResourceDictionary jezici
        {
            get { return Application.Current.Resources.MergedDictionaries[5]; }
        }
        private readonly Korisnik trenutniKorisnik;
        private List<Kupovina> kupovina= new List<Kupovina>();
        private List<Rezervacija> rezervacija=new List<Rezervacija>();
        private List<Aranzman> destinacije = new List<Aranzman>();
        int count = 1;
        public Kupac(Korisnik korisnik)
        {
            InitializeComponent();
            trenutniKorisnik = korisnik;
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            SearchLabel.Visibility = Visibility.Hidden;
            SearchButton.Visibility = Visibility.Hidden;
        }

        private void Aranzmani_Click(object sender, RoutedEventArgs e)
        {
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Visible;
            SearchLabel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            destinacije = DbUtil.getDestinacije().FindAll(aranzman=>aranzman.Datum_polaska>DateTime.Today);
            grid1.ItemsSource = destinacije;

        }

        private void Kupovine_Click(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Visible;
            SearchLabel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            kupovina = DbUtil.getKupovina(trenutniKorisnik);
            grid2.ItemsSource = kupovina;

        }

        private void Rezervacije_Click(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Visible;
            SearchLabel.Visibility = Visibility.Visible;
            SearchButton.Visibility = Visibility.Visible;
            rezervacija = DbUtil.getRezervacija(trenutniKorisnik);
            grid3.ItemsSource =rezervacija;
        }

        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            new Profil(trenutniKorisnik).Show();
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void grid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Aranzman aranzman = (Aranzman)grid1.SelectedItem;
            new AranzmanDetaljnoKupac(aranzman, trenutniKorisnik).Show();
            Close();
        }

        private void DarkButton_Click(object sender, RoutedEventArgs e)
        {
            count = 1;
            themes.MergedDictionaries.Clear();
            themes.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Dark.xaml")

            });
            DbUtil.updateKorisnika(count,trenutniKorisnik);
            new Kupac(trenutniKorisnik).Show();
            Close();
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            count = 2;
            themes.MergedDictionaries.Clear();
            themes.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Blue.xaml")

            });
            DbUtil.updateKorisnika(count,trenutniKorisnik);
            new Kupac(trenutniKorisnik).Show();
            Close();
        }

        private void WhiteButton_Click(object sender, RoutedEventArgs e)
        {
            count = 3;
            themes.MergedDictionaries.Clear();
            themes.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Light.xaml")

            });
            DbUtil.updateKorisnika(count, trenutniKorisnik);
            new Kupac(trenutniKorisnik).Show();
            Close();
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            jezici.MergedDictionaries.Clear();
            jezici.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Engleski.xaml")

            });
            new Kupac(trenutniKorisnik).Show();
            Close();
        }

        private void Serbia_Click(object sender, RoutedEventArgs e)
        {
            jezici.MergedDictionaries.Clear();
            jezici.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Srpski.xaml")

            });
            new Kupac(trenutniKorisnik).Show();
            Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(grid1.Visibility==Visibility.Visible && SearchLabel.Text.Length > 0)
            {
                    var aranzmani = DbUtil.getDestinacije().FindAll(aranzman => aranzman.Grad.ToUpper().Equals(SearchLabel.Text.ToUpper()));
                    grid1.ItemsSource = aranzmani;
            }
            else if(grid2.Visibility==Visibility.Visible && SearchLabel.Text.Length > 0)
            {
                    var kupovine = DbUtil.getKupovina(trenutniKorisnik).FindAll(aranzman => aranzman.Grad.ToUpper().Equals(SearchLabel.Text.ToUpper()));
                    grid2.ItemsSource = kupovine;
            }
            else if(grid3.Visibility==Visibility.Visible && SearchLabel.Text.Length > 0)
            {
                try
                {
                    var rezervacije = DbUtil.getRezervacija(trenutniKorisnik).FindAll(rezervacija => rezervacija.Datum_rezervacije.Date.Equals(DateTime.Parse(SearchLabel.Text)));
                    grid3.ItemsSource = rezervacije;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(FindResource("incorrectinput") as string, "Error");

                }
            }
        }

        private void SearchLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchLabel.Text.Length <= 0 && grid1.Visibility == Visibility.Visible)
            {
                grid1.ItemsSource = destinacije;

            }
            else if (SearchLabel.Text.Length <= 0 && grid2.Visibility == Visibility.Visible)
            {
                grid2.ItemsSource = kupovina;

            }
            else if (SearchLabel.Text.Length <= 0 && grid3.Visibility == Visibility.Visible)
            {
                grid3.ItemsSource = rezervacija;

            }
        }
    }
}
