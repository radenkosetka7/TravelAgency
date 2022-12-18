using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TravelAgencyWpfHci.Model
{
    internal class DbUtil
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public static Korisnik login(string username,string password)
        {
            Korisnik korisnik = null;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * from `korisnik`";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(username==reader.GetString(6) && password==reader.GetString(7))
                    {
                        korisnik = new Korisnik()
                        {
                            Jmbg = reader.GetString(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Datum_rodjenja = reader.GetDateTime(3),
                            Broj_telefona = reader.GetString(4),
                            Email = reader.GetString(5),
                            Korisnicko_ime = reader.GetString(6),
                            Lozinka = reader.GetString(7),
                            Tema = reader.GetInt32(8),
                            Rola = reader.GetInt32(9)
                        };
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            return korisnik;
        }

        public static int provjeriDrzavu(string drzava)
        {
            List<Drzava> drzave = new List<Drzava>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from `drzava`";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    drzave.Add(new Drzava()
                    {
                        IdDrzave = reader.GetInt32(0),
                        NazivDrzave = reader.GetString(1)
                    });
                }
                for(int i=0;i<drzave.Count;i++)
                {
                    if(drzave[i].NazivDrzave.Equals(drzava))
                    {
                        return drzave[i].IdDrzave;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static int provjeriGrad(string grad)
        {
            List<Grad> gradovi = new List<Grad>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from `destinacija`";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    gradovi.Add(new Grad()
                    {
                        IdGrada = reader.GetInt32(0),
                        NazivGrada = reader.GetString(1)
                    });
                }
                for (int i = 0; i < gradovi.Count; i++)
                {
                    if (gradovi[i].NazivGrada.Equals(grad))
                    {
                        return gradovi[i].IdGrada;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static int dodajDrzavu(string drzava)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT into drzava(Naziv_drzave) values(@Drzava)";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Drzava", drzava);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = connection.CreateCommand();
                int id = (int)cmd.LastInsertedId;
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static int dodajGrad(string grad,string opis,int idDrzave,byte[] slika)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT into destinacija(Grad,Opis,DRZAVA_idDrzave,Slika) values(@Grad,@Opis,@idDrzave,@Slika)";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Grad", grad);
                cmd.Parameters.AddWithValue("@Opis", opis);
                cmd.Parameters.AddWithValue("@idDrzave", idDrzave);
                cmd.Parameters.AddWithValue("@Slika", slika);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = connection.CreateCommand();
                int id = (int)cmd.LastInsertedId;
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static void dodajAranzman(Korisnik korisnik,string grad,string drzava,string opis,string polazak,string povratak,string cijena,string mjesta,BitmapImage image)
        {
            int idDrzave = provjeriDrzavu(drzava);
            int idGrada = provjeriGrad(grad);
            byte[] slika = bitmapToBytes(image);
            if(idDrzave == 0)
            {
                idDrzave = dodajDrzavu(drzava);
            }
            if(idGrada==0)
            {
                idGrada = dodajGrad(grad, opis,idDrzave, slika);
            }
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT into aranzman(Datum_polaska,Datum_povratka,Cijena,Broj_mjesta,DESTINACIJA_idDestinacije,KORISNIK_JMBG) values(@Polazak,@Povratak,@Cijena,@Broj_mjesta,@IdDestinacije,@JMBG)";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Polazak", DateTime.Parse(polazak).Date);
                cmd.Parameters.AddWithValue("@Povratak", DateTime.Parse(povratak).Date);
                cmd.Parameters.AddWithValue("@Cijena", Decimal.Parse(cijena));
                cmd.Parameters.AddWithValue("@Broj_mjesta", Int32.Parse(mjesta));
                cmd.Parameters.AddWithValue("@IdDestinacije", idGrada);
                cmd.Parameters.AddWithValue("@JMBG", korisnik.Jmbg);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static void updateKorisnika(int tema,Korisnik korisnik)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = $"UPDATE `korisnik` set Tema=@tema where JMBG={korisnik.Jmbg}";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@tema", tema);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static List<Rezervacija> getRezervacija(Korisnik korisnik)
        {
            List<Rezervacija> rezervacija = new List<Rezervacija>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT ARANZMAN_idAranzmana,Kolicina,r.KORISNIK_JMBG,r.DatumRezervacije,Grad,a.Datum_polaska from `rezervacija_stavka` rs inner join `rezervacija` r on r.idRezervacije=rs.REZERVACIJA_idRezervacije inner join aranzman a on a.idAranzmana=rs.ARANZMAN_idAranzmana inner join destinacija d on a.DESTINACIJA_idDestinacije=d.idDestinacije where r.KORISNIK_JMBG={korisnik.Jmbg}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rezervacija.Add(new Rezervacija()
                    {
                        Id_aranzmana = reader.GetInt32(0),
                        Kolicina = reader.GetInt32(1),
                        Kupac_jmbg = reader.GetString(2),
                        Datum_rezervacije = reader.GetDateTime(3),
                        Grad=reader.GetString(4),
                        Datum_polaska=reader.GetDateTime(5).Date
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            return rezervacija;

        }

        public static void dodajRezervaciju(Aranzman aranzman,Korisnik korisnik,string kolicina,string datum)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT into rezervacija(DatumRezervacije,KORISNIK_JMBG) values(@Datum,@JMBG)";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Datum", DateTime.Parse(datum).Date);
                cmd.Parameters.AddWithValue("@JMBG", korisnik.Jmbg);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = connection.CreateCommand();
                int id = (int)cmd.LastInsertedId;
                string query1 = "INSERT into rezervacija_stavka(ARANZMAN_idAranzmana,REZERVACIJA_idRezervacije,Kolicina) values(@idAranzmana,@idRezervacije,@Kolicina)";
                cmd1.CommandText = query1;
                cmd1.Parameters.AddWithValue("@idAranzmana", aranzman.Id_aranzmana);
                cmd1.Parameters.AddWithValue("@idRezervacije", id);
                cmd1.Parameters.AddWithValue("@Kolicina", Int32.Parse(kolicina));
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static void dodajKupovinu(Aranzman aranzman,Korisnik korisnik,string kolicina)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT into kupovina(KORISNIK_JMBG) values(@JMBG)";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@JMBG", korisnik.Jmbg);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = connection.CreateCommand();
                int id = (int)cmd.LastInsertedId;
                string query1 = "INSERT into kupovina_stavka(KUPOVINA_idKupovine,ARANZMAN_idAranzmana,Kolicina) values(@idKupovine,@idAranzmana,@Kolicina)";
                cmd1.CommandText = query1;
                cmd1.Parameters.AddWithValue("@idKupovine", id);
                cmd1.Parameters.AddWithValue("@idAranzmana", aranzman.Id_aranzmana);
                cmd1.Parameters.AddWithValue("@Kolicina", Int32.Parse(kolicina));
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public static List<Kupovina> getKupovina(Korisnik korisnik)
        {
            List<Kupovina> kupovina = new List<Kupovina>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT ARANZMAN_idAranzmana,Kolicina,k.KORISNIK_JMBG,Grad,a.Datum_polaska from `kupovina_stavka` ks inner join `kupovina` k on k.idKupovine=ks.KUPOVINA_idKupovine inner join aranzman a on a.idAranzmana=ks.ARANZMAN_idAranzmana inner join destinacija d on a.DESTINACIJA_idDestinacije=d.idDestinacije where k.KORISNIK_JMBG={korisnik.Jmbg}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    kupovina.Add(new Kupovina()
                    {
                        Id_aranzmana = reader.GetInt32(0),
                        Kolicina = reader.GetInt32(1),
                        Kupac_jmbg = reader.GetString(2),
                        Grad=reader.GetString(3),
                        Datum_polaska=reader.GetDateTime(4).Date
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return kupovina;

        }
        public static List<Kupovina> getKupovine()
        {
            List<Kupovina> kupovina = new List<Kupovina>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ARANZMAN_idAranzmana,Kolicina,k.KORISNIK_JMBG,Grad,a.Datum_polaska from `kupovina_stavka` ks inner join `kupovina` k on k.idKupovine=ks.KUPOVINA_idKupovine inner join aranzman a on a.idAranzmana=ks.ARANZMAN_idAranzmana inner join destinacija d on a.DESTINACIJA_idDestinacije=d.idDestinacije";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    kupovina.Add( new Kupovina()
                    {
                        Id_aranzmana = reader.GetInt32(0),
                        Kolicina = reader.GetInt32(1),
                        Kupac_jmbg = reader.GetString(2),
                        Grad=reader.GetString(3),
                        Datum_polaska=reader.GetDateTime(4).Date
                    });

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            return kupovina;

        }

        public static List<Rezervacija> getRezervacije()
        {
            List<Rezervacija> rezervacija = new List<Rezervacija>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ARANZMAN_idAranzmana,Kolicina,r.KORISNIK_JMBG,r.DatumRezervacije,Grad,a.Datum_polaska from `rezervacija_stavka` rs inner join `rezervacija` r on r.idRezervacije=rs.REZERVACIJA_idRezervacije inner join aranzman a on a.idAranzmana=rs.ARANZMAN_idAranzmana inner join destinacija d on a.DESTINACIJA_idDestinacije=d.idDestinacije";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rezervacija.Add(new Rezervacija()
                    {
                        Id_aranzmana = reader.GetInt32(0),
                        Kolicina = reader.GetInt32(1),
                        Kupac_jmbg = reader.GetString(2),
                        Datum_rezervacije=reader.GetDateTime(3),
                        Grad=reader.GetString(4),
                        Datum_polaska=reader.GetDateTime(5)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            return rezervacija;

        }
        public static Korisnik getKorisnik(string jmbg)
        {
            Korisnik korisnik = null;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * from `korisnik` where JMBG={jmbg}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                        korisnik = new Korisnik()
                        {
                            Jmbg = reader.GetString(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Datum_rodjenja = reader.GetDateTime(3),
                            Broj_telefona = reader.GetString(4),
                            Email = reader.GetString(5),
                            Korisnicko_ime = reader.GetString(6),
                            Lozinka = reader.GetString(7),
                            Tema = reader.GetInt32(8),
                            Rola = reader.GetInt32(9)
                        };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return korisnik;
        }
        public static void updateKorisnika(string ime,string prezime, string email,
            string broj_telefona, DateTime datum_rodjenja, string korisnicko_ime, string lozinka,Korisnik korisnik)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "UPDATE `korisnik` set Ime=@Ime, Prezime=@Prezime, Datum_rodjenja=@Datum_rodjenja, Broj_telefona=@Broj_telefona, Email=@Email, Korisnicko_ime=@Korisnicko_ime, Lozinka=@Lozinka where JMBG=@JMBG";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Ime", ime);
                cmd.Parameters.AddWithValue("@Prezime", prezime);
                cmd.Parameters.AddWithValue("@Broj_telefona", broj_telefona);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Korisnicko_ime", korisnicko_ime);
                cmd.Parameters.AddWithValue("@Lozinka", lozinka);
                cmd.Parameters.AddWithValue("@Datum_rodjenja", datum_rodjenja);
                cmd.Parameters.AddWithValue("@JMBG", korisnik.Jmbg);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static void updateAranzman(string grad,string drzava,DateTime polazak,
            DateTime povratak,string cijena,string broj,Aranzman aranzman,Korisnik korisnik)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "UPDATE `aranzman` set idAranzmana=@id_aranzmana, Datum_polaska=@DatumPol, Datum_povratka=@DatumPov, Cijena=@Cijena, Broj_mjesta=@Mjesta, DESTINACIJA_idDestinacije=@Destinacija, KORISNIK_JMBG=@JMBG where idAranzmana=@id_aranzmana";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id_aranzmana", aranzman.Id_aranzmana);
                cmd.Parameters.AddWithValue("@DatumPol", polazak);
                cmd.Parameters.AddWithValue("@DatumPov", povratak);
                cmd.Parameters.AddWithValue("@Cijena", Decimal.Parse(cijena));
                cmd.Parameters.AddWithValue("@Mjesta", Int32.Parse(broj));
                cmd.Parameters.AddWithValue("@Destinacija", aranzman.Id_destinacije);
                cmd.Parameters.AddWithValue("@JMBG", korisnik.Jmbg);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static void obrisiAranzman(Aranzman aranzman)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "DELETE from `aranzman` where idAranzmana=@id_aranzmana";
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id_aranzmana", aranzman.Id_aranzmana);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static List<Aranzman> getDestinacije()
        {
            List<Aranzman> rezultat = new List<Aranzman>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            DataTable table=new DataTable();
            MySqlDataReader reader = null;
            try
            {
                string query= "SELECT idAranzmana,Datum_polaska,Datum_povratka,Cijena,Broj_mjesta,Opis,Slika,Naziv_drzave,Grad,idDestinacije from `destinacija` d inner join" +
                    "`aranzman` a on a.DESTINACIJA_idDestinacije=d.idDestinacije inner join drzava dr on dr.idDrzave=d.DRZAVA_idDrzave";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                connection.Open();
                table.Load(cmd.ExecuteReader());
                connection.Close();
                Aranzman aranzman = null;
                foreach(DataRow row in table.Rows)
                {
                    rezultat.Add(new Aranzman()
                    {
                        Id_aranzmana=row.Field<int>("idAranzmana"),
                        Datum_polaska=row.Field<DateTime>("Datum_polaska"),
                        Datum_povratka=row.Field<DateTime>("Datum_povratka"),
                        Cijena=row.Field<decimal>("Cijena"),
                        Broj_mjesta=row.Field<int>("Broj_mjesta"),
                        Opis=row.Field<string>("Opis"),
                        Slika=bytesToBitmap(row.Field<byte[]>("Slika")),
                        Naziv_drzave=row.Field<string>("Naziv_drzave"),
                        Grad=row.Field<string>("Grad"),
                        Id_destinacije=row.Field<int>("idDestinacije"),
                   });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (connection != null)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return rezultat;
        }

        public static BitmapImage bytesToBitmap(byte[] arr)
        {
            BitmapImage image = new BitmapImage();
            MemoryStream stream = new MemoryStream(arr);
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
        public static byte[] bitmapToBytes(BitmapImage image)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            MemoryStream ms = new MemoryStream();
            encoder.Save(ms);
            return ms.ToArray();
        }

    }
}
