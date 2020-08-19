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

        public void ChooseSoda(SodaMachine machine)
        {
            UserInterface.DisplaySodaInventory(machine.inventory);
            UserInterface.GetUserInputInt("Please pick the number of the soda you would like!");

        }

        

        

        
    }
}
