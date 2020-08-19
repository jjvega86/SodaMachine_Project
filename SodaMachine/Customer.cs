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

        public void SelectCoins()
        {

        }

        public int ChooseSoda(SodaMachine machine)
        {
            UserInterface.DisplaySodaInventory(machine.inventory);
            intInput = UserInterface.GetUserInputInt("Please pick the number of the soda you would like!");
            return intInput;
        }

        

        

        
    }
}
