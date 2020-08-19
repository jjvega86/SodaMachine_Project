using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> coins;
        public Card card;

        public Wallet()
        {
            coins = new List<Coin>();
            AddCoinsToWallet(new Quarter(), 12);
            AddCoinsToWallet(new Dime(), 12);
            AddCoinsToWallet(new Nickel(), 12);
            AddCoinsToWallet(new Penny(), 20);

            card = new Card();
        }

        private void AddCoinsToWallet(Coin coin, int count) 
        {
            for (int i = 0; i < count; i++)
            {
                coins.Add(coin);
            }
        }

        public double GetTotalCoins() 
        {
            double totalValue = 0;
            for (int i = 0; i < coins.Count; i++)
            {
                totalValue += coins[i].Value;

            }

            return totalValue;

        }
    }
}
