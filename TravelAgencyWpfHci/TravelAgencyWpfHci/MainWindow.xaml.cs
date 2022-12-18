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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelAgencyWpfHci.Model;

namespace TravelAgencyWpfHci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ResourceDictionary themes
        {
            get { return Application.Current.Resources.MergedDictionaries[4]; }
        }
        public static ResourceDictionary jezici
        {
            get { return Application.Current.Resources.MergedDictionaries[5]; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtUsername.Text!="")
            {
                if(txtPassword.Password.ToString() !="")
                {
                    Korisnik korisnik = DbUtil.login(txtUsername.Text, txtPassword.Password.ToString());
                    if(korisnik!=null && korisnik.Rola==1)
                    {
                        if (korisnik.Tema == 1)
                        {
                            themes.MergedDictionaries.Clear();
                            themes.MergedDictionaries.Add(new ResourceDictionary()
                            {
                                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Dark.xaml")

                            });
                        }
                        else if (korisnik.Tema == 2)
                        {
                            themes.MergedDictionaries.Clear();
                            themes.MergedDictionaries.Add(new ResourceDictionary()
                            {
                                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Blue.xaml")

                            });
                        }
                        else if (korisnik.Tema == 3)
                        {
                            themes.MergedDictionaries.Clear();
                            themes.MergedDictionaries.Add(new ResourceDictionary()
                            {
                                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Light.xaml")

                            });
                        }
                        new view.Zaposleni(korisnik).Show();
                        Close();
                    }
                    else if(korisnik!=null && korisnik.Rola==2)
                    {
                        if (korisnik.Tema == 1)
                        {
                            themes.MergedDictionaries.Clear();
                            themes.MergedDictionaries.Add(new ResourceDictionary()
                            {
                                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Dark.xaml")

                            });
                        }
                        else if (korisnik.Tema == 2)
                        {
                            themes.MergedDictionaries.Clear();
                            themes.MergedDictionaries.Add(new ResourceDictionary()
                            {
                                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Blue.xaml")

                            });
                        }
                        else if (korisnik.Tema == 3)
                        {
                            themes.MergedDictionaries.Clear();
                            themes.MergedDictionaries.Add(new ResourceDictionary()
                            {
                                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Light.xaml")

                            });
                        }
                        new view.Kupac(korisnik).Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(FindResource("invalidcredentials")as string,"Error");
                    }
                }
                else
                {
                    MessageBox.Show(FindResource("insertpass") as string, "Error");

                }
            }
            else
            {
                MessageBox.Show(FindResource("insertusername") as string, "Error");

            }
        }

        private void DarkButton_Click(object sender, RoutedEventArgs e)
        {
            themes.MergedDictionaries.Clear();
            themes.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Dark.xaml")

            });
            new MainWindow().Show();
            Close();
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            themes.MergedDictionaries.Clear();
            themes.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Blue.xaml")

            });
            new MainWindow().Show();
            Close();
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            themes.MergedDictionaries.Clear();
            themes.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Light.xaml")

            });
            new MainWindow().Show();
            Close();
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            jezici.MergedDictionaries.Clear();
            jezici.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Engleski.xaml")

            });
            new MainWindow().Show();
            Close();
        }

        private void Serbia_Click(object sender, RoutedEventArgs e)
        {
            jezici.MergedDictionaries.Clear();
            jezici.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TravelAgencyWpfHci;component/Themes/Srpski.xaml")

            });
            new MainWindow().Show();
            Close();
        }
    }
}
