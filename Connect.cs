using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace krypto
{
    class connect
    {
        private HttpClient client = new HttpClient();        // utworzenie polaczenia z klientem http 

        public connect()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  //ustawienie oczekianej wiadomosci zwrotnej
        }
        public async Task<double> ProcessRepositories_usd(string adress)     // metoda pobrania wartosci usd portfela
        {
            var stringTask = client.GetStringAsync(adress); //wysałnie zapytania 
            Values_json d = JsonSerializer.Deserialize<Values_json>(await stringTask); // odebranie zapytania
            return d.Todouble_usd();

        }
        public async Task<double> ProcessRepositories_eth(string adress) // metoda pobrania wartosci eth portfela
        {
            var stringTask = client.GetStringAsync(adress); //wysałnie zapytania 
            Values_json d = JsonSerializer.Deserialize<Values_json>(await stringTask);  //odebranie zapytania 
            return d.ToDouble_eth();
        }
        public async Task<double> ProcessRepositories_eth_price(string adress)  //metoda pobrania ceny eth 
        {
            var stringTask = client.GetStringAsync(adress); //wysałnie zapytania 
            Price_json d = JsonSerializer.Deserialize<Price_json>(await stringTask); //obranie zapytania 
            return d.ToDouble_cena_eth();
        }
    }
}