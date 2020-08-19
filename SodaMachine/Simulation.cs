using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }

        public void RunSimulation() 
        {
            bool validateInput = false;
            // What would you like to do?
            //1. Display Wallet contents (total amount of funds, in what currency)
            //2. Display Soda options and prices
            //3. Choose soda
            //4. Pay for soda
            //5. Take soda and store in bookbag

            while (validateInput == false)
            {
                int userInput = UserInterface.DisplayUserOptions(); //returns user input as int. Pass as parameter for Soda Machine method
                if (userInput == 1)
                {
                    sodaMachine.DisplaySodaInventory();
                }
                else if (userInput == 2)
                {
                    customer.DisplayWallet();
                }
                else if (userInput == 3)
                {
                    sodaMachine.ChooseSoda();
                }

            }
            

        }
    }
}
