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

       






    }
}
