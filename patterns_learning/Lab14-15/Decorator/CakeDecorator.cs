using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Decorator
{
    abstract class CakeDecorator : Cake
    {
        protected Cake Cake;
        public CakeDecorator(string n, Cake Cake) : base(n)
        {
            this.Cake = Cake;
        }
    }
}
