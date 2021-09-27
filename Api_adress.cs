using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krypto
{
    class Api_adress  //tworzy adresy zapytan 
    {
        string[] adres_wallet_b = new string[30]; //adresy binance na sieci eth 

        string adres_base = "https://api.etherscan.io/api"; //adres bazowy
        string check_balance = "?module=account&action=tokenbalance"; //sprawdzenie ilosci tokenow

        string eth_price = "?module=stats&action=ethprice";          //sprawdzenie ceny eth

        string adres_usdt = "&contractaddress=0xdac17f958d2ee523a2206206994597c13d831ec7"; //adres usdt
        string adres_usdc = "&contractaddress=0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48";  // adres usdc

        string adres_eth = "?module=account&action=balance";// wartosc eth na koncie

        string api_key = "&apikey=********************************"; //api key

        public Api_adress()
        {
            /////////////////////////////////////////////////////////////////////////////////////// binance
            adres_wallet_b[0] = "&address=0x3f5CE5FBFe3E9af3971dD833D26bA9b5C936f0bE&tag=latest";
            adres_wallet_b[1] = "&address=0xD551234Ae421e3BCBA99A0Da6d736074f22192FF&tag=latest";
            adres_wallet_b[2] = "&address=0x564286362092D8e7936f0549571a803B203aAceD&tag=latest";
            adres_wallet_b[3] = "&address=0x0681d8Db095565FE8A346fA0277bFfdE9C0eDBBF&tag=latest";
            adres_wallet_b[4] = "&address=0xfe9e8709d3215310075d67e3ed32a380ccf451c8&tag=latest";
            adres_wallet_b[5] = "&address=0x4e9ce36e442e55ecd9025b9a6e0d88485d628a67&tag=latest";
            adres_wallet_b[6] = "&address=0xbe0eb53f46cd790cd13851d5eff43d12404d33e8&tag=latest";
            adres_wallet_b[7] = "&address=0xf977814e90da44bfa03b6295a0616a897441acec&tag=latest";
            adres_wallet_b[8] = "&address=0x001866ae5b3de6caa5a51543fd9fb64f524f5478&tag=latest";
            adres_wallet_b[9] = "&address=0x85b931a32a0725be14285b66f1a22178c672d69b&tag=latest";
            adres_wallet_b[10] = "&address=0x708396f17127c42383e3b9014072679b2f60b82f&tag=latest";
            adres_wallet_b[11] = "&address=0xe0f0cfde7ee664943906f17f7f14342e76a5cec7&tag=latest";
            adres_wallet_b[12] = "&address=0x8f22f2063d253846b53609231ed80fa571bc0c8f&tag=latest";
            adres_wallet_b[13] = "&address=0x28C6c06298d514Db089934071355E5743bf21d60&tag=latest";
            adres_wallet_b[14] = "&address=0x21a31Ee1afC51d94C2eFcCAa2092aD1028285549&tag=latest";
            adres_wallet_b[15] = "&address=0xDFd5293D8e347dFe59E90eFd55b2956a1343963d&tag=latest";
            adres_wallet_b[16] = "&address=0x56Eddb7aa87536c09CCc2793473599fD21A8b17F&tag=latest";
            adres_wallet_b[17] = "&address=0x9696f59E4d72E237BE84fFD425DCaD154Bf96976&tag=latest";
            adres_wallet_b[18] = "&address=0x4D9fF50EF4dA947364BB9650892B2554e7BE5E2B&tag=latest";
            adres_wallet_b[19] = "&address=0x4976A4A02f38326660D17bf34b431dC6e2eb2327&tag=latest";
            /////////////////////////////////////////////////////////////////////////////////////////////////////coinbase
            adres_wallet_b[20] = "&address=0x71660c4005ba85c37ccec55d0c4493e66fe775d3&tag=latest";
            adres_wallet_b[21] = "&address=0x503828976d22510aad0201ac7ec88293211d23da&tag=latest";
            adres_wallet_b[22] = "&address=0xddfabcdc4d8ffc6d5beaf154f18b778f892a0740&tag=latest";
            adres_wallet_b[23] = "&address=0x3cd751e6b0078be393132286c442345e5dc49699&tag=latest";
            adres_wallet_b[24] = "&address=0xb5d85cbf7cb3ee0d56b3bb207d5fc4b82f43f511&tag=latest";
            adres_wallet_b[25] = "&address=0xeb2629a2734e272bcc07bda959863f316f4bd4cf&tag=latest";
            ///////////////////////////////////////////////////////////////////////////////////////////kucoin
            adres_wallet_b[26] = "&address=0x2b5634c42055806a59e9107ed44d43c426e58258&tag=latest";
            adres_wallet_b[27] = "&address=0x689c56aef474df92d44a1b70850f808488f9769c&tag=latest";
            adres_wallet_b[28] = "&address=0xa1d8d972560c2f8144af871db508f0b0b10a3fbf&tag=latest";
            adres_wallet_b[29] = "&address=0x4ad64983349c49defe8d7a4686202d24b25d0ce8&tag=latest";
        }
        public string get_usdt_b(int i) //zwraca adres pobrania ilosc usdt 
        {
            return adres_base + check_balance + adres_usdt + adres_wallet_b[i] + api_key;
        }

        public string get_eth_b(int i) //zwraca adres pobrania ilosci eth
        {
            return adres_base + adres_eth + adres_wallet_b[i] + api_key;
        }
        public string get_usdc_b(int i) //zwraca adres pobrania ilosci usdc
        {
            return adres_base + check_balance + adres_usdc + adres_wallet_b[i] + api_key;
        }
        public string get_cena_eth() //zwraca adres pobrania ceny eth
        {
            return adres_base + eth_price + api_key;
        }
    }
}