using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace krypto
{
    class Program
    {

        static async Task Main(string[] args)
        {

            connect a = new connect();    // tworzy polaczenie z klientem http ethscan 
            Api_adress adress_base = new Api_adress();   // tworzy adresy zapytan 
            Bot bot = new Bot();   //tworzy bota telegram 
            Values w = new Values();  // wartosci sum danych pobranych 
            Date_base db = new Date_base();  //polaczenie z baza danych

            double temp_usdc = 0;     // zmienna do liczenia sumy usd
            double temp_eth = 0;      // zmienna do liczenia sumy eth
            double temp_usd = 0;      // zmienna do liczenia sumy usd

            w.suma_eth_p = db.Pobranie_ostatniej_wartosci_eth();  // pobranie ostatniej zapisanej wartosci sumy eth z bazy danych 
            w.suma_usd_p = db.Pobranie_ostatniej_wartosci_usd();  // pobranie ostatniej zapisanej wartosci sumy usd z bazy danych 

            while (true) // zapewnia ciagle dzialanie programu 
            {
                try
                {
                    for (int i = 0; i < 30; i++)    //wysylanie zapytan do kolejnych adresow portweli
                    {
                        Console.WriteLine(i);
                        temp_eth = await a.ProcessRepositories_eth(adress_base.get_eth_b(i));    // pobranie ilosci eth z portfela 
                        temp_usd = await a.ProcessRepositories_usd(adress_base.get_usdt_b(i));   // pobranie ilosci usdt z portfela
                        temp_usdc = await a.ProcessRepositories_usd(adress_base.get_usdc_b(i));  // pobranie ilosci usdc z portfela

                        w.suma_usd = w.suma_usd + temp_usd + temp_usdc;  //sumowanie usd
                        w.suma_eth = w.suma_eth + temp_eth;              //sumowanie eth

                        Task.Delay(600).Wait();                          // opoznienie zapytania aby nie przekroczyc 5 na 1 sek.
                    }

                    Console.WriteLine("eth: " + w.suma_eth);
                    Console.WriteLine("usd: " + w.suma_usd);

                }
                catch (Exception e)  // wylapanie bledu podczas podczas zapytan 
                {
                    System.Console.WriteLine(e);
                }

                DateTime thisHour = DateTime.Now;            //pobranie czasu
                Console.WriteLine(thisHour.ToString() + " ");    //wypisanie czasu

                try
                {
                    w.cena_eth = await a.ProcessRepositories_eth_price(adress_base.get_cena_eth());  // pobranie ceny eth

                }
                catch (Exception e) // wylapanie bledu podczas podczas zapytania o cene eth
                {
                    Console.WriteLine(e);
                }

                bot.send(w); // wyslanie danych na teleram 

                db.EthToDateBase(w); // wysłanie danych o eth do bazy danych
                db.UsdToDateBase(w); // wysąlnie danych o usd do bazy danych

                w.next(); //  zapisanie sumy jako poprzedniej i czysczenie 

                Task.Delay(240 * 60 * 1000).Wait();    //opoznienie do nastepnego pobrania danych za 4h
            }
        }
    }
}