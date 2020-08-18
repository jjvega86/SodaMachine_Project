using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        public double GetWalletCoinValue()
        {
            double totalValue = 0;
            for (int i = 0; i < wallet.coins.Count; i++)
            {
                totalValue += wallet.coins[i].Value;

            }

            return totalValue;
        }

        public void SelectCoins(Wallet wallet)
        {
            foreach(Coin coin in wallet.coins)
            {

            }
            
        }
    }
}
