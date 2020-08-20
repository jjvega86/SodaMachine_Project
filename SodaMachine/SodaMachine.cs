using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;
        string userSelection;
        int userSelectionIndex;
        public List<Coin> customerChange;

        public SodaMachine()
        {
            register = new List<Coin>();           
            AddCoinsToRegister(new Quarter(), 20);
            AddCoinsToRegister(new Dime(), 10);
            AddCoinsToRegister(new Nickel(), 20);
            AddCoinsToRegister(new Penny(), 50);           
            inventory = new List<Can>();
            AddCansToInventory(new Cola(), 25);
            AddCansToInventory(new OrangeSoda(), 25);
            AddCansToInventory(new RootBeer(), 25);

            userSelection = "";
            userSelectionIndex = 0;
            customerChange = new List<Coin>();
        }

        private void AddCoinsToRegister(Coin coin, int count)
        {
            for (int i = 0; i < count; i++)
            {
                register.Add(coin);
            }
        }

        private void AddCansToInventory(Can can, int count)
        {
            for (int i = 0; i < count; i++)
            {
                inventory.Add(can);
            }

        }

        private void AddPaymentToRegister(List<Coin> payment)
        {
            for (int j = 0; j < payment.Count; j++)
            {
                register.Add(payment[j]);

            }
        }

        public bool ValidateTransaction(List<Coin> payment, string input) 
        {
            bool transactionSuccess = false;
            

            for (int i = 0; i < inventory.Count; i++)
            {
                if(input == inventory[i].name)
                {
                    userSelectionIndex = i;


                    if(inventory[i].Cost == UserInterface.CalculateTotal(payment))
                    {
                        transactionSuccess = true;
                        AddPaymentToRegister(payment);
                        userSelection = input;
                        break;
                    }

                    if (inventory[i].Cost > UserInterface.CalculateTotal(payment))
                    {
                        UserInterface.InsufficientFunds(payment);
                        //then need to give money back
                        //re-prompt for money (SelectCoins?)
                    }

                    if(inventory[i].Cost < UserInterface.CalculateTotal(payment))
                    {
                        transactionSuccess = true;
                         //return of eventual seperate method

                        while (inventory[i].Cost < UserInterface.CalculateTotal(payment))
                        {
                           customerChange.Add(payment[0]);
                           payment.RemoveAt(0);
                           // need logic that adds coins from register to change if removed coins is less than change needed

                        }
                        AddPaymentToRegister(payment);
                    }

                    // if too much money is passed in but there isn't sufficient change in register, transactionSuccess == false
                    //money goes back to customer

                    //if there isn't sufficient inventory for the sodas, don't complete the transaction and give money back
                    
                }

            }

            return transactionSuccess;
        }


        

        public Can DispenseSoda(bool transactionSuccess)
        {
            int index = 0;
            if (transactionSuccess == true)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].name.Contains(userSelection))
                    {
                        
                        inventory.RemoveAt(i);
                        index = i;
                        break;
                        
                        
                    }

                }

            }
            return inventory[index];


        }














    }
}
