using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Coin
    {
        protected double value;

        // user story: a read-only property that is public, so the user can see but cannot set the value of protect field "value" 
        // making the private variable "value" protected allows child classes to inherit
        public double Value 
        {
            get
            {
                return value;
            } 
        
        } 
        
        public string name;

        public Coin()
        {
            value = 0.0;
            name = "Coin";
        }

        // Is there a way to make this AddCoin method at a level that allows it to be used by other classes 
        // that need it?
        //public void AddCoin(Coin coin, List<Coin> list, int count) 
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        list.Add(coin);
        //    }

        //}


    }
}
