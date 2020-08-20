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

        public bool ValidateSelection(List<Coin> payment, string input) 
        {
            bool transactionSuccess = false;
            

            for (int i = 0; i < inventory.Count; i++)
            {
                if(input == inventory[i].name)
                {
                    if(inventory[i].Cost <= UserInterface.CalculateTotal(payment))
                    {
                        transactionSuccess = true;
                        userSelection = input;
                        break;
                    }

                    if (inventory[i].Cost > UserInterface.CalculateTotal(payment))
                    {
                        UserInterface.InsufficientFunds(payment);
                        //then need to give money back
                    }
                    
                }

            }

            return transactionSuccess;
        }

        public void ValidateTransactionMaster(List<Coin> payment) //only validates money, not soda selection
        {
            


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
