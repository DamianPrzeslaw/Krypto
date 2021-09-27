using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace krypto
{
    struct Values  //przechowuje podstawowe wartosci 
    {
        public double suma_eth;  
        public double suma_usd;
        public double suma_usd_p;  //porzednia suma usd
        public double suma_eth_p; // porzednia suma eth
        public double cena_eth;

        public double get_delta_eth() // zwraca delte eth 
        {
            return suma_eth - suma_eth_p;
        }
        public double get_delta_usd() //zwraca delte usd
        { 
            return suma_usd - suma_usd_p; 
        }
        public int get_eth_cena() // zwraca zaokraglona cene eth
        {
            return Convert.ToInt32(Math.Round(cena_eth));
        }
        public string get_eth_to_write()  //zwraca wartosc eth w odpowiednim formacie do wypisania 
        {
            return  suma_eth.ToString("0,0", CultureInfo.InvariantCulture);
        }
        public string get_usd_to_write()  //zwraca wartosc usd w odpowiednim formacie do wypisania 
        {
            return suma_usd.ToString("0,0", CultureInfo.InvariantCulture);
        }
        public string get_delta_eth_to_write() //zwraca delte eth w odpowiednim formacie do wypisania 
        {
            return get_delta_eth().ToString("0,0", CultureInfo.InvariantCulture);
        }
        public string get_delta_usd_to_write() //zwraca delte usd w odpowiednim formacie do wypisania 
        {
            return get_delta_usd().ToString("0,0", CultureInfo.InvariantCulture);
        }
        public void next()  // zapisuje sume wartosci jako poprzednia i zeruje sume
        {
            suma_eth_p = suma_eth;
            suma_eth = 0;

            suma_usd_p = suma_usd;
            suma_usd = 0;
        }
    }
}
