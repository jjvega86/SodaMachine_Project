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
            bool choiceComplete = false;
            List<Coin> payment = new List<Coin>();
            UserInterface.DisplayCoins(wallet.coins);
           
            while(choiceComplete == false)
            {
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
                stringInput = UserInterface.GetUserInputString("Do you want to select any more?");

                if (stringInput == "Yes")
                {
                    continue;
                }
                else
                {
                    choiceComplete = true;
                }


            } 
            return payment;

        }

       

        public void ChooseSoda(SodaMachine machine)
        {
            //Display the soda inventory
            //Get user's choice as a string
            //compare user choice to inventory
            //if choice is available, 
            UserInterface.DisplaySodaInventory(machine.inventory);
            stringInput = UserInterface.GetUserInputString("Please pick the soda you would like!");
            machine.CheckInventory(stringInput);
            
        }

        public void PayForSoda()
        {
            //take return from SelectCoins and ChooseSoda
            //if payment is equal to value of soda, remove from inventory
            //Add soda to backpack
        }

        public void AddSodaToBackpack()
        {

        }

        

        

        
    }
}
