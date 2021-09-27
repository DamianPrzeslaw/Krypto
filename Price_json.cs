using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace krypto
{
    public class Price_json  // klasa odpowiadajaca pobraniu odpowiedzi json o cenie eth
    {
        public string status { get; set; }
        public string message { get; set; }
        public Result result { get; set; }

        public double ToDouble_cena_eth()
        {
            return double.Parse(result.ethusd, CultureInfo.InvariantCulture.NumberFormat); // zwrot wartosci ceny eth w double 
        }
    }
    public class Result
    {
        public string ethbtc { get; set; }
        public string ethbtc_timestamp { get; set; }
        public string ethusd { get; set; }
        public string ethusd_timestamp { get; set; }
    }

}
