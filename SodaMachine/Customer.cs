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

       

        public void GetSoda(SodaMachine machine)
        {

            stringInput = UserInterface.GetUserInputString("Please pick the soda you would like!");

            for (int  i = 0;  i < machine.inventory.Count;  i++)
            {
                if (machine.inventory[i].name.Contains(stringInput))
                {
                    AddSodaToBackpack(machine.inventory[i]);
                    machine.inventory.RemoveAt(i);
                }

            }
            
        }

        public void CheckPayment()
        {
            //check select coins against cost of soda. If equal to cost, add soda to backpack and remove from
            //inventory. Then ANOTHER method to add payment to register.
        }

        public void PayForSoda(List<Coin> payment, Can soda)
        {
            //take return from SelectCoins and ChooseSoda
            //if payment is equal to value of soda, remove from inventory
            //Add soda to backpack
        }

        public void AddSodaToBackpack(Can can)
        {
            backpack.cans.Add(can);
        }

        

        

        
    }
}
