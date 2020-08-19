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
        int intInput;
        string stringInput;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            intInput = 0;
        }


        public List<Coin> SelectCoins(Wallet wallet)
        {
            List<Coin> payment = new List<Coin>();
            UserInterface.DisplayCoins(wallet.coins);
            stringInput = UserInterface.GetUserInputString("Which type of coins would you like to use?");
            intInput = UserInterface.GetUserInputInt("How many of those coins would you like to use?");

            
            for (int i = 0; i < intInput; i++)
            {
                foreach (Coin coin in wallet.coins)
                {
                    if (stringInput == coin.name)
                    {
                        payment.Add(coin);
                    }
                }
                

            }

            return payment;

        }

        public int ChooseSoda(SodaMachine machine)
        {
            UserInterface.DisplaySodaInventory(machine.inventory);
            intInput = UserInterface.GetUserInputInt("Please pick the number of the soda you would like!");
            return intInput;
        }

        

        

        
    }
}
