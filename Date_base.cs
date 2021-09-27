using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace krypto
{
    class Date_base
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder  // dane logowania do bazy danej 
        {
            Server = "*********",
            Database = "*****",
            UserID = "*****",
            Password = "*****",
        };

        public void EthToDateBase(Values w)  // metoda wysyla wartosci eth do bazy danej 
        {
            MySqlConnection connect = new MySqlConnection(builder.ConnectionString); //tworzy polaczenie z baza danych 
   
            DateTime thisHour = DateTime.Now;          // pobranie czasu 

            string s = string.Format(   // tworzy tresc komendy sql do wstawienia wiersza do bazy 
                "INSERT INTO Eth (dzien,godzina,suma,delta,cena) VALUES('{0}','{1}', {2}, {3},{4});",
                 thisHour.ToString("yyyy-MM-dd"),
                 thisHour.ToString("HH:mm"),
                 Math.Round(w.suma_eth),
                Math.Round( w.get_delta_eth()),
                 w.get_eth_cena()
                 ) ;

            try
            {
                Console.Write("eth ->");
                connect.Open();                    // otwarcie polaczenia z baza danych 
                MySqlCommand komenda = connect.CreateCommand();   //  sworzenie komendy sql
                komenda.CommandText = s;        //  przypisanie tresci komendy 
              //  komenda.ExecuteReader();        // wykonanie komendy sql
                Console.WriteLine("done");
            }
            catch (Exception e)     // wypisanie bledu z baza danych 
            {
                Console.WriteLine("nie udane");
                Console.WriteLine(e);
            }
        }
        public void UsdToDateBase(Values w)  // metoda wysyla wartosci usd do bazy danej 
        {
            MySqlConnection connect = new MySqlConnection(builder.ConnectionString); //tworzy polaczenie z baza danych 

            DateTime thisHour = DateTime.Now; // pobranie czasu 

            string s = string.Format(     // tworzy tresc komendy sql do wstawienia wiersza do bazy
                "INSERT INTO Usd (dzien,godzina,suma,delta) VALUES('{0}','{1}', {2}, {3});",
                 thisHour.ToString("yyyy-MM-dd"),
                 thisHour.ToString("HH:mm"),
                 Math.Round(w.suma_usd),
                Math.Round(w.get_delta_usd())
                ); 

            try
            {
                Console.Write("usd ->");      
                connect.Open();               // otwarcie polaczenia z baza danych 
                MySqlCommand komenda = connect.CreateCommand();    //  sworzenie komendy sql
                komenda.CommandText = s;      //  przypisanie tresci komendy 
           //     komenda.ExecuteReader();      // wykonanie komendy sql
                Console.WriteLine("done");
                
            }

            catch (Exception e)      // wypisanie bledu z baza danych 
            {
                Console.WriteLine("nie udane");
                Console.WriteLine(e);
            }
        }
        public double Pobranie_ostatniej_wartosci_usd()  //pobiera ostatnia wartosc sumy usd 
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(builder.ConnectionString); //tworzy polaczenie z baza danych 
                connect.Open();               // otwarcie polaczenia z baza danych 

                MySqlCommand komenda = connect.CreateCommand();    //  sworzenie komendy sql
                komenda.CommandText = "SELECT suma FROM Usd ORDER BY id DESC LIMIT 1;";  //komenda pobrania ostatniej sumy usd

                MySqlDataReader czytnik = komenda.ExecuteReader();  //wykoanie komendy i owatcie czytnika 
                czytnik.Read();                     // pobranie wartosci

                return czytnik.GetInt64(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("nie udane pobranie wartosci usd z bazy danych");
                return 0;
            }
            
        }

        public double Pobranie_ostatniej_wartosci_eth() //pobiera ostatnia wartosc sumy usd 

        {
            try 
            {
                MySqlConnection connect = new MySqlConnection(builder.ConnectionString); //tworzy polaczenie z baza danych 
                connect.Open();               // otwarcie polaczenia z baza danych 

                MySqlCommand komenda = connect.CreateCommand();    //  sworzenie komendy sql
                komenda.CommandText = "SELECT suma FROM Eth ORDER BY id DESC LIMIT 1;"; //komenda pobrania ostatniej sumy eth

                MySqlDataReader czytnik = komenda.ExecuteReader(); //wykoanie komendy i owatcie czytnika 
                czytnik.Read();  // pobranie wartosci

                return czytnik.GetInt32(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("nie udane pobranie wartosci eth z bazy danych");
                return 0;
            }
        }

    }
}
