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
            AddQuartersToRegister();
            AddDimesToRegister();
            AddNickelsToRegister();
            AddPenniesToRegister();
            inventory = new List<Can>();
        }

        private void AddQuartersToRegister()
        {
            int count = 20;
            for (int i = 0; i < count; i++)
            {
                Quarter quarter = new Quarter();
                register.Add(quarter);

            }
        }

        private void AddDimesToRegister()
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                Dime dime = new Dime();
                register.Add(dime);

            }
        }

        private void AddNickelsToRegister()
        {
            int count = 20;
            for (int i = 0; i < count; i++)
            {
                Nickel nickel = new Nickel();
                register.Add(nickel);

            }
        }

        private void AddPenniesToRegister()
        {
            int count = 50;
            for (int i = 0; i < count; i++)
            {
                Penny penny = new Penny();
                register.Add(penny);

            }
        }






    }
}
