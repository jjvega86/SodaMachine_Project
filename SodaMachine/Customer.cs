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

        
        public void SelectSoda() // customer class
        {

        }

        public double DisplayWallet() // customer class
        {
            double totalValue = 0;
            for (int i = 0; i < wallet.coins.Count; i++)
            {
                totalValue += wallet.coins[i].Value;

            }

            return totalValue;

        }

        public void SelectPayment(Wallet wallet) // customer class
        {
            //need user input to select how much to take out
            //where is the List that stores the payment?
            foreach (Coin coin in wallet.coins)
            {

            }

        }

        public void InsertPayment() // customer class
        {

        }

        public void StoreSoda() // customer class
        {

        }
    }
}
