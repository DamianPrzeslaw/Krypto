using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Telegram.Bot;
namespace krypto
{
    class Bot   //bot wysylajacy wiadomosci na telegram 
    {
        public TelegramBotClient Client;
        string api_key;  //api_key bot
        int id; // id rozmowy 

        public Bot()
        {
            api_key = "************************"; //apki key bot telegram
   
              id = 123456; //id grupy 
          
            Client = new TelegramBotClient(api_key);   //polaczenie z botem telegram
        }
        public void send(Values w)  //metoda wyslanie wiadomosci na telegram
        {
          
            double procent_eth =w.get_delta_eth() / w.suma_eth;        //obliczneie procentow zmiany eth
            double procent_usd =w.get_delta_usd() / w.suma_usd;      // obiczanie procent zmiany usd

            procent_eth = Math.Round(procent_eth * 100, 2);          //zaokraglenie wartosci procentowej eth
            procent_usd = Math.Round(procent_usd * 100, 2);         //zaokraglenie wartosci procentowej  usd


            Client.SendTextMessageAsync(id, "eth: " + w.get_delta_eth_to_write() + " (" + procent_eth + "%)\n" + "usd: " + w.get_delta_usd_to_write() + " (" + procent_usd + "%)"); //wyslanie wiadomosci
        }

    }
}