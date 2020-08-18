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
        public double Value { get; } // user story: a read-only property that is public, so the user can see but cannot set the value of protect field "value" 
                                    // making the private variable "value" protected allows child classes to inherit
        public string name;

        public Coin()
        {
            value = 0.0;
            name = "Coin";
        }


    }
}
