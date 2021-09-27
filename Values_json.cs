using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krypto
{
    class Values_json   // klasa odpowiadjaca pobraniu odpowiedzi json o ilosci tokenow 
    {
        public string status { get; set; }
        public string message { get; set; }
        public string result { get; set; }


        public decimal ToDecimal()  // zwraca wartosc w decimal 
        {
            decimal a = Convert.ToDecimal(result);
            a = a / 1000000000000000000;  //wartosc eth jest podana w 10^-18
            return a;
        }

        public double ToDouble_eth() // zwraca wartosc eth w double 
        {
            decimal a = Convert.ToDecimal(result);
            a = a / 1000000000000000000; // wartosc eth jest podana w 10 ^ -18
            a = Math.Round(a, 2);        // zaokragla do drugiego miejsca po przecinku 
            return Convert.ToDouble(a);  
        }

        public double Todouble_usd()  // zwraca wartosc eth w double 
        {
            decimal a = Convert.ToDecimal(result);
            a = a / 1000000;         // wartosc eth jest podana w 10 ^ -6
            a = Math.Round(a, 2);     
            return Convert.ToDouble(a);
        }

    }
}