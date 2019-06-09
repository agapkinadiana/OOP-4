using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Decorator
{
    class ThereCake : CakeDecorator
    {
        public ThereCake(Cake p)
            : base(p.Name + ", есть на месте", p)
        { }

        public override int GetCost()
        {
            return Cake.GetCost() - 1;
        }
    }
}
